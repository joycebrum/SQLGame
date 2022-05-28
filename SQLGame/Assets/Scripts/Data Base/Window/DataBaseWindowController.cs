﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI.TableUI;
using System.Data;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using Mono.Data.SqliteClient;

public class DataBaseWindowController: MonoBehaviour
{
    [SerializeField] private TableUI table;
    [SerializeField] private DataBase database;
    [SerializeField] private GameObject scrollView;
    [SerializeField] private InputField queryInput;
    [SerializeField] private Text errorText;
    [SerializeField] private TutorialController tutorial;

    [SerializeField] GameObject tableDataPrefable;
    [SerializeField] Transform sideBar;

    [SerializeField] private StageController stageController;

    [SerializeField] private GameObject popUp;
    [SerializeField] private OperationalSystemController main;

    List<Tuple<string, string>> headerData = new List<Tuple<string, string>>();
    List<List<string>> tableData = new List<List<string>>();

    private List<string> sqlHistory = new List<string>();
    private int historyPosition = -1;


    private void Start()
    {
        if (tutorial.checkTutorial("DBTutorialComplete"))
        {
            tutorial.StartTutorial(FinishTutorial);
        }
        InitializeTableData();
    }
    public void DropdownValueChanged(Dropdown change)
    {
        switch(change.value)
        {
            case 0: break;
            case 1:
                queryInput.text = "SELECT * FROM NomeDaTabela;";
                break;
            case 2:
                queryInput.text = "SELECT coluna1, coluna2 FROM tabela;";
                break;
            case 3:
                queryInput.text = "SELECT * FROM NomeDaTabela WHERE nomeColuna = valor;";
                break;
            case 4:
                queryInput.text = "SELECT * FROM NomeDaTabela WHERE colunaData > 'AAAA-MM-DD' and colunaData < 'AAAA-MM-DD';";
                break;
            case 5:
                queryInput.text = "SELECT * FROM PrimeiraTabela x JOIN SegundaTabela y ON x.coluna = y.coluna;";
                break;
            default:
                break;
        }

        change.value = 0;
    }

    public void InitializeTableData()
    {
        this.scrollView.SetActive(false);
        IDataReader reader = database.QueryCommand("SELECT name FROM sqlite_master WHERE type='table';");
        sideBar.DetachChildren();
        while (reader.Read())
        {
            string tableName = (string)reader["name"];

            if (tableName == "sqlite_sequence") continue;

            GameObject clone = Instantiate(tableDataPrefable);
            clone.transform.SetParent(sideBar);

            TableDataController tableDataController = clone.GetComponent<TableDataController>();
            tableDataController.TableTitle = tableName;
            
            IDataReader tableData = database.QueryCommand("PRAGMA table_info(" + tableName + ");");

            while (tableData.Read())
            {
                tableDataController.AddColumn((string)tableData["name"], (string)tableData["type"]);
            }
        }
    }

    void GetDBValues(string sqlQuery)
    {
        //string pragmaQuery = "PRAGMA table_info(" + tableName +  ");";
        IDataReader reader = database.QueryCommand(sqlQuery);
        
        for (int i = 0; i < reader.FieldCount; i++)
        {
            headerData.Add(new Tuple<string, string>(reader.GetName(i), reader.GetDataTypeName(i)));
        }

        UpdateTableData(reader: reader);
    }

    void UpdateTable()
    {

        if(tableData.Count > 499) {
            throw new SqliteSyntaxException(message: "O numero de <color=red>LINHAS</color> execedeu o limite que pode ser exibido na tabela. Tente limitar o numero de linhas exibidas com aa clausulas <color=green>LIMIT</color> ou <color=green>WHERE</color>");
        } else if(headerData.Count > 10)
        {
            throw new SqliteSyntaxException(message: "O numero de <color=red>COLUNAS</color> execedeu o limite que pode ser exibido na tabela. Tente selecionar colunas especificas no <color=green>SELECT</color>");
        }
        //setup table
        table.Columns = headerData.Count;
        table.Rows = tableData.Count + 1;

        //initialize table
        for (int i=0; i<headerData.Count; i++)
        {
            table.GetCell(0, i).text = headerData[i].Item1;
        }
        for(int i=0; i< tableData.Count; i++)
        {
            int maxCharacters = 0;
            for (int j=0; j< tableData[i].Count; j++)
            {
                table.GetCell(i + 1, j).text = tableData[i][j];
                table.GetCell(i + 1, j).enableWordWrapping = true;
                if(tableData[i][j].Length > maxCharacters)
                {
                    maxCharacters = tableData[i][j].Length;
                }
            }
            if (maxCharacters > 150)
            {
                table.UpdateRowHeight(200, i + 1);
            }
            else if (maxCharacters > 100)
            {
                table.UpdateRowHeight(150, i + 1);
            }
            else
            {
                table.UpdateRowHeight(70, i + 1);
            }
        }

        if(table.Rows == 2) {
            CheckResult();
        }
    }

    void UpdateTableData(IDataReader reader)
    {
        while (reader.Read())
        {
            List<string> lineContent = new List<string>();
            foreach (Tuple<string, string> columnData in headerData)
            {
                lineContent.Add(Cast(columnData.Item1, columnData.Item2, reader));
            }
            tableData.Add(lineContent);

        }
    }

    void ClearTableData()
    {
        headerData.Clear();
        tableData.Clear();
    }

    private string Cast(string name, string type, IDataReader reader)
    {
        switch (type)
        {
            case "date":
            case "datetime":
                return ((DateTime)reader[name]).ToString();
            default:
                return reader[name].ToString();
        }
    }

    public void Search()
    {
        string sqlQuery = queryInput.text.Trim();

        if(!String.IsNullOrEmpty(sqlQuery) && this.IsSqlValid(sqlQuery))
        {
            try
            {
                this.ClearTableData();

                this.GetDBValues(sqlQuery);
                this.UpdateTable();

                errorText.gameObject.SetActive(false);
                this.scrollView.SetActive(true);

                this.sqlHistory.Add(sqlQuery);
                this.historyPosition = -1;
            }
            catch (SqliteSyntaxException e)
            {
                SetErrorMessage(translateErrorMessage(e.Message));
            }
        }
    }

    private string translateErrorMessage(string msg)
    {
        if(msg.StartsWith("no such column:"))
        {
            return msg.Replace("no such column:", "Nenhuma coluna <color=red>") + "</color> encontrada";
        }
        if(msg.StartsWith("no such table:"))
        {
            return msg.Replace("no such table:", "Nenhuma tabela <color=red>") + "</color> encontrada";
        }
        if(Regex.Match(msg, @"near\s*"".+"":\s*syntax error").Success)
        {
            return "Erro de sintaxe próximo a <color=red>" + Regex.Match(msg, @""".+""").Value + "</color>";
        }
        if (Regex.Match(msg, @"incomplete\s+input").Success)
        {
            return "Comando SQL incompleto.";
        }
        return msg;
    }

    private bool IsSqlValid(string sqlQuery)
    {
        List<string> errors = SqlValidator.Validate(sqlQuery);
        if (errors != null && errors.Count != 0)
        {
            string msg = "";

            foreach (string error in errors)
            {
                msg += error;
                msg += "\n";
            }
            SetErrorMessage(msg);
            return false;
        }
        return true;
    }

    private void SetErrorMessage(string msg)
    {
        errorText.text = msg;
        this.scrollView.SetActive(false);
        errorText.gameObject.SetActive(true);
    }

    private void CheckResult()
    {
        List<string> headerNames = headerData.ConvertAll<string>(FirstItemsConverter);
        if (stageController.CheckForClues(headerNames, tableData[0]))
        {
            popUp.GetComponent<PopUpController>().showPopUp("Parabéns, voce encontrou uma pista!");
        }
    }

    public static string FirstItemsConverter(Tuple<string,string> tuple)
    {
        return tuple.Item1;
    }

    public void PreviousQuery()
    {
        if (this.sqlHistory.Count() == 0) return;
        this.historyPosition = GetPosition(-1);
        print(this.historyPosition);
        this.queryInput.text = this.sqlHistory[this.historyPosition];
    }

    public void NextQuery()
    {
        if (this.sqlHistory.Count() == 0) return;
        this.historyPosition = GetPosition(1);
        print(this.historyPosition);
        this.queryInput.text = this.sqlHistory[this.historyPosition];
    }

    private int GetPosition(int direction) 
    {
        if(direction == 0)  return this.historyPosition;

        if(this.historyPosition == -1)
        {
            if (this.queryInput.text == this.sqlHistory[this.sqlHistory.Count() - 1]) return this.sqlHistory.Count() - 2;
            return this.sqlHistory.Count() - 1;
        }

        direction = direction / Mathf.Abs(direction); //should receive 1 or -1
        int position = this.historyPosition + direction;

        if (position < 0) return 0;
        if (position >= this.sqlHistory.Count()) return this.sqlHistory.Count() - 1;

        return position;
    }

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt("DBTutorialComplete", 1);
        main.TutorialCompleted();
    }
}
