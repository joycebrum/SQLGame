using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DataBaseScreenFunctions: MonoBehaviour
{

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
        for(int i = 0; i< 10; i++)
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
        //table.table.HeaderColor = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
