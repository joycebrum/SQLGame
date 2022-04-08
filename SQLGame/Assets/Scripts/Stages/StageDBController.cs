using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StageDBController : MonoBehaviour
{
    public DataBase database;
    public void InitDabaBase(string dbPath, string sqlCreatePath, string sqlPopulatePath)
    {
        print("inicio");
        bool fileExists = System.IO.File.Exists(dbPath);
        print("file exists: " + fileExists);
        this.database.Connect(dbPath);
        print("terminou o connect");
        if (!fileExists)
        {
            print("antes do create");
            CreateDataBase(sqlCreatePath);
            print("depois do create");
            PopulateDataBase(sqlPopulatePath);
            print("depois do populate");
        }
    }

    private void CreateDataBase(string sqlCreatePath)
    {
        database.NonQueryCommand(ReadFromFile(sqlCreatePath));
    }

    private void PopulateDataBase(string sqlPopulatePath)
    {
        string sql = ReadFromFile(sqlPopulatePath);
        database.NonQueryCommand(sql);
    }

    private string ReadFromFile(string path)
    {
        string sqlText = Resources.Load<TextAsset>(path).text;
        return sqlText;
    }
}
