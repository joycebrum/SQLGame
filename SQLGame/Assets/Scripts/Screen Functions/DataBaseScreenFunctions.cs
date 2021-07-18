using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class DataBaseScreenFunctions: MonoBehaviour
{
    public TableUI table;

    List<string> headerMock = new List<string>();
    List<List<string>> tableMock = new List<List<string>>();
    List<float> columnWidth = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        startMock();
        startTable();
    }

    void startMock()
    {
        //Header
        headerMock.Add("aaa");
        headerMock.Add("bbb");
        headerMock.Add("cccccccccccccccccccccc");
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
    } 

    void startTable()
    {
        //setup table

        table.Columns = headerMock.Count;
        table.Rows = tableMock.Count+1;

        //initialize table
        for(int i=0; i<headerMock.Count; i++)
        {
            table.GetCell(0, i).text = headerMock[i];
        }
        for(int i=0; i< tableMock.Count; i++)
        {
            print("count: " +tableMock[i].Count);
            for (int j=0; j<tableMock[i].Count; j++)
            {
                print("i: " + i + " | j: " + j);
                table.GetCell(i + 1, j).text = tableMock[i][j]; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
