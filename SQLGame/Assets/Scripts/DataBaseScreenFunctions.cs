using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DataBaseScreenFunctions: MonoBehaviour
{

    public GameObject header;
    public GameObject table;
    public Text text;
    public GameObject tableLine;

    List<string> headerMock = new List<string>();
    List<List<string>> tableMock = new List<List<string>>();

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
        headerMock.Add("ccc");
        // table
        List<List<string>> mock = new List<List<string>>();
        int count = 0;
        for(int i = 0; i< 10; i++)
        {
            List<string> temp = new List<string>();
            for(int j = 0; j < 3; j++)
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
        // Header
        text.text = headerMock[0];
        for(int i=1; i<headerMock.Count; i++)
        {
            Text clone = Instantiate(text);
            clone.text = headerMock[i];
            //clone.rectTransform.sizeDelta = new Vector2(130, 53);
            clone.transform.SetParent(header.transform);
            clone.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Table
        //tableText.text = tableMock[0][0];
        GameObject emptyLine = Instantiate(tableLine);
        for(int i=0; i < tableMock.Count; i++)
        {
            GameObject line = new GameObject();
            if (i != 0)
            {
                line = Instantiate(emptyLine);
            } else
            {
                line = tableLine;
            }

            Text clone = Instantiate(text);
            clone.text = tableMock[i][0];
            clone.transform.SetParent(line.transform);
            clone.transform.localScale = new Vector3(1f, 1f, 1f);

            for (int j=1; j<tableMock[i].Count; j++)
            {
                clone = Instantiate(text);
                clone.text = tableMock[i][j];
                clone.transform.SetParent(line.transform);
                clone.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (i != 0)
            {
                line.transform.SetParent(table.transform);
                line.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
