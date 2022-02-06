using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableDataController : MonoBehaviour
{

    [SerializeField] private Text tableTitle;
    [SerializeField] GameObject columnTextPrefab;
    [SerializeField] Transform columnListTransform;
    public string TableTitle
    {
        get { return tableTitle.text; }  
        set { tableTitle.text = value; }
    }

    public void AddColumn(string name, string type)
    {
        GameObject clone = Instantiate(columnTextPrefab);
        clone.GetComponent<Text>().text = name + " " + type;
        clone.transform.SetParent(columnListTransform);
    }
}
