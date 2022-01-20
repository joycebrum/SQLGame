using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI.TableUI;
using System.Data;
using System;

public class DataBaseWindowController: MonoBehaviour
{
    public TableUI table;
    public DataBase database;

    public Dropdown firstDropDown;
    public Dropdown secondDropDown;
    public Dropdown thirdDropDown;
    public InputField firstInputField;
    public InputField secondInputField;
    public InputField thirdInputField;

    // List<string> headerMock = new List<string>();
    // List<List<string>> tableMock = new List<List<string>>();
    List<Tuple<string, string>> headerData = new List<Tuple<string, string>>();
    List<List<string>> tableData = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        SetSearchMechanism();
        GetDBValues();
        UpdateTable();
    }

    void SetSearchMechanism()
    {
        List<string> firstList = new List<string> { "select", "insert" };
        firstDropDown.options.Clear();
        List<string> secondList = new List<string> { "from" };
        secondDropDown.options.Clear();
        List<string> thirdList = new List<string> { "where" };
        thirdDropDown.options.Clear();
        foreach (string option in firstList)
        {
            firstDropDown.options.Add(new Dropdown.OptionData(option));
        }
        foreach (string option in secondList)
        {
            secondDropDown.options.Add(new Dropdown.OptionData(option));
        }
        foreach (string option in thirdList)
        {
            thirdDropDown.options.Add(new Dropdown.OptionData(option));
        }
    }

    void GetDBValues()
    {
        string sqlQuery = "PRAGMA table_info(Alunos);";
        IDataReader reader = database.QueryCommand(sqlQuery);

        while (reader.Read())
        {
            string columnName = (string)reader["name"];
            string columnType = (string)reader["type"];
            headerData.Add(new Tuple<string, string>(columnName, columnType));
        }

        sqlQuery = "SELECT * FROM Alunos";
        reader = database.QueryCommand(sqlQuery);

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
            /*string name = (string)reader["name"];
            int value = (int)reader["score"];
            string score = value.ToString();

            List<string> temp = new List<string>();
            temp.Add(name);
            temp.Add(score);
            tableData.Add(temp);*/

            List<string> lineContent = new List<string>();
            foreach (Tuple<string, string> columnData in headerData)
            {
                lineContent.Add(cast(columnData.Item1, columnData.Item2, reader));
            }
            tableData.Add(lineContent);

        }
    }

    void ClearTableData()
    {
        tableData.Clear();
    }

    public void OnClickSearchButton()
    {
        //string sqlQuery = "select * from teste where name='Thiago'";
        string firstDropDownValue = firstDropDown.options[firstDropDown.value].text;
        string secondDropDownValue = secondDropDown.options[secondDropDown.value].text;
        string thirdDropDownValue = thirdDropDown.options[thirdDropDown.value].text;

        string sqlQuery = firstDropDownValue + " " + firstInputField.text + " " + secondDropDownValue + " " + secondInputField.text + " " + thirdDropDownValue + " " + thirdInputField.text;
        Debug.Log(sqlQuery);

        IDataReader reader = database.QueryCommand(sqlQuery);

        UpdateTableData(reader: reader);
        UpdateTable();
    }

    private string cast(string name, string type, IDataReader reader)
    {
        switch(type)
        {
            case "DATE":
                return ((DateTime)reader[name]).ToString();
            default:
                return(string)reader[name];
        }
    }
}
