using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StageDBController : MonoBehaviour
{
    public DataBase database;
    public void InitDabaBase(string dbPath, string sqlCreatePath, string sqlPopulatePath)
    {
        bool fileExists = System.IO.File.Exists(dbPath);
        this.database.Connect("URI=file:" + dbPath);
        if (!fileExists)
        {
            print("inicio");
            CreateDataBase(sqlCreatePath);
            print("meio");
            PopulateDataBase(sqlPopulatePath);
            print("fim");
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
        StreamReader reader = new StreamReader(path);
        string sqlCreateText = reader.ReadToEnd();
        reader.Close();
        return sqlCreateText;
    }
}
