using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StageOneDBController : MonoBehaviour
{
    public DataBase database;
    private string sqlCreatePath = "Assets/Resources/Stage 1/createDB.txt";
    private string sqlPopulatePath = "Assets/Resources/Stage 1/populateDB.txt";
    private string dbPath = "db/Stage1SQLite.db";
    // Start is called before the first frame update
    void Start()
    {
        InitDabaBase();
    }

    public void InitDabaBase()
    {
        this.database.Connect("URI=file:" + this.dbPath);
        if (!System.IO.File.Exists(dbPath))
        {
            CreateDataBase();
            PopulateDataBase();
        }
    }

    private void CreateDataBase()
    {
        database.NonQueryCommand(ReadFromFile(sqlCreatePath));
    }

    private void PopulateDataBase()
    {
        string sql = ReadFromFile(sqlPopulatePath);
        database.NonQueryCommand(sql);
    }

    private string ReadFromFile(string path)
    {
        StreamReader reader = new StreamReader(path);
        string sqlCreateText = reader.ReadToEnd();
        reader.Close();
        return sqlCreateText;
    }
}
