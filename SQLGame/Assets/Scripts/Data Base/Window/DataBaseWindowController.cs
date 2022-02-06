using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI.TableUI;
using System.Data;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class DataBaseWindowController: MonoBehaviour
{
    [SerializeField] private TableUI table;
    [SerializeField] private DataBase database;
    [SerializeField] private GameObject scrollView;
    [SerializeField] private InputField queryInput;
    [SerializeField] private Text errorText;

    // List<string> headerMock = new List<string>();
    // List<List<string>> tableMock = new List<List<string>>();
    List<Tuple<string, string>> headerData = new List<Tuple<string, string>>();
    List<List<string>> tableData = new List<List<string>>();

    private void Start()
    {
        this.scrollView.SetActive(false);
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
        switch(type)
        {
            case "date":
                return ((DateTime)reader[name]).ToString();
            default:
                return(string)reader[name];
        }
    }

    public void Search()
    {
        string sqlQuery = queryInput.text;

        if(String.IsNullOrEmpty(sqlQuery) || !this.IsSqlValid(sqlQuery))
        {
            this.scrollView.SetActive(false);
        } 
        else
        {
            this.scrollView.SetActive(true);
            this.ClearTableData();

            this.GetDBValues(sqlQuery);
            this.UpdateTable();
        }
    }

    private bool IsSqlValid(string sqlQuery)
    {
        List<string> errors = SqlValidator.Validate(sqlQuery);
        if (errors != null && errors.Count != 0)
        {
            errorText.text = "";

            foreach (string error in errors)
            {
                errorText.text += error;
                errorText.text += "\n";
            }

            errorText.gameObject.SetActive(true);

            return false;
        }
        return true;
    }
}
