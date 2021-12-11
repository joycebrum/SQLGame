using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI.TableUI;
using System.Data;

public class DataBaseWindowController: MonoBehaviour
{
    public TableUI table;
    public DataBase database;

    // List<string> headerMock = new List<string>();
    // List<List<string>> tableMock = new List<List<string>>();
    List<string> headerData = new List<string>();
    List<List<string>> tableData = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        // StartMock();
        GetDBValues();
        StartTable();
    }

    /*void StartMock()
    {
        //Header
        headerMock.Add("aaa");
        headerMock.Add("bbb");
        headerMock.Add("MMMMMMMMMMMMMMMMMM MMMMMMMMMMMMMMMMMMMMMMM MMMMMMMM MMMMMMMMMMMM");
        headerMock.Add("ddd");
        // table
        List<List<string>> mock = new List<List<string>>();
        int count = 0;
        for(int i = 0; i< 17; i++)
        {
            List<string> temp = new List<string>();
            for(int j = 0; j < 4; j++)
            {
                temp.Add(count.ToString());
                count++;
            }
            mock.Add(temp);
        }
        tableMock = mock;
    }*/

    void GetDBValues()
    {
        string sqlQuery = "PRAGMA table_info(teste);";
        IDataReader reader = database.QueryCommand(sqlQuery);

        while (reader.Read())
        {
            string columnName = (string)reader["name"];
            headerData.Add(columnName);
        }

        sqlQuery = "SELECT * FROM teste";
        reader = database.QueryCommand(sqlQuery);

        while (reader.Read())
        {
            string name = (string)reader["name"];
            int value = (int)reader["score"];
            string score = value.ToString();

            List<string> temp = new List<string>();
            temp.Add(name);
            temp.Add(score);
            tableData.Add(temp);

        }
    }

    void StartTable()
    {
        //setup table

        table.Columns = headerData.Count;
        table.Rows = tableData.Count+1;
        Debug.Log(tableData.Count);

        //initialize table
        for(int i=0; i<headerData.Count; i++)
        {
            table.GetCell(0, i).text = headerData[i];
        }
        for(int i=0; i< tableData.Count; i++)
        {
            for (int j=0; j< tableData[i].Count; j++)
            {
                table.GetCell(i + 1, j).text = tableData[i][j]; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
