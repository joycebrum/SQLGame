using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestingDataBase : MonoBehaviour
{
    public string nameField;
    public string number;
    public DataBase database;

    public void Start()
    {
        string sql = "CREATE TABLE IF NOT EXISTS teste(name VARCHAR(20), score INT)";
        database.NonQueryCommand(sql);
        Debug.Log("Criado com sucesso");
    }

    public void Inserir()
    {
        string sql = "INSERT INTO teste(name, score) VALUES('" + nameField + "', "+ number +")";
        database.NonQueryCommand(sql);
        Debug.Log("Inserido com sucesso");
    }

    public void Recuperar()
    {
        string sqlQuery = "SELECT * FROM teste";
        IDataReader reader = database.QueryCommand(sqlQuery);

        while (reader.Read())
        {
            string name = (string)reader["name"];
            int value = (int)reader["score"];

            Debug.Log("value = " + value + " name = " + name);
        }
    }
}
