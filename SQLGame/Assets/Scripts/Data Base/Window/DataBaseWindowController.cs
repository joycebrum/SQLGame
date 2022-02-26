using System.Collections;
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

    [SerializeField] GameObject tableDataPrefable;
    [SerializeField] Transform sideBar;

    [SerializeField] private StageController stageOneController;

    List<Tuple<string, string>> headerData = new List<Tuple<string, string>>();
    List<List<string>> tableData = new List<List<string>>();

    private void Start()
    {
        this.scrollView.SetActive(false);
        InitializeTableData();
    }

    void InitializeTableData()
    {
        IDataReader reader = database.QueryCommand("SELECT name FROM sqlite_master WHERE type='table';");

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
            for (int j=0; j< tableData[i].Count; j++)
            {
                table.GetCell(i + 1, j).text = tableData[i][j]; 
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
        print("type: " + type);
        switch(type)
        {
            case "date":
            case "datetime":
                return ((DateTime)reader[name]).ToString();
            case "integer":
                return reader[name].ToString();
            default:
                return (string)reader[name];
        }
    }

    public void Search()
    {
        string sqlQuery = queryInput.text;

        if(!String.IsNullOrEmpty(sqlQuery) && this.IsSqlValid(sqlQuery))
        {
            try
            {
                this.ClearTableData();

                this.GetDBValues(sqlQuery);
                this.UpdateTable();

                errorText.gameObject.SetActive(false);
                this.scrollView.SetActive(true);
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
        stageOneController.FindClue(3);
    }
}
