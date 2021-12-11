using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneDBController : MonoBehaviour
{
    public DataBase database;
    // Start is called before the first frame update
    void Start()
    {
        StartDB();
        PopulateDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDB()
    {
        this.database.Connect("URI=file:db/MasterSQLite.db");
        string sql = "drop table teste";
        database.QueryCommand(sql);
        sql = "CREATE TABLE teste(name VARCHAR(20), score INT)";
        database.NonQueryCommand(sql);
    }

    void PopulateDB()
    {
        string sql = "INSERT INTO teste(name, score) VALUES('Thiago', 45)";
        database.NonQueryCommand(sql);
        sql = "INSERT INTO teste(name, score) VALUES('Jocye', 40)";
        database.NonQueryCommand(sql);
    }
}
