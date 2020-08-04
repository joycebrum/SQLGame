using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class DataBase : MonoBehaviour
{
    // caminho para o arquivo do banco

    string urlDataBase = "URI=file:MasterSQLite.db";
    private IDbConnection _connection;

    public void Start()
    {
        string sql = "CREATE TABLE IF NOT EXISTS teste(name VARCHAR(20), score INT)";
        _connection = new SqliteConnection(urlDataBase);
        _connection.Open();

        IDbCommand _command = _connection.CreateCommand();

        _command.CommandText = sql;
        _command.ExecuteNonQuery();
        Debug.Log("Criado com sucesso");
    }

    public void Inserir() {
        string sql = "INSERT INTO teste(name, score) VALUES('Me', 3000)";
        IDbCommand _command = _connection.CreateCommand();
        _command.CommandText = sql;
        _command.ExecuteNonQuery();
        Debug.Log("Inserido com sucesso");
    }
     
    public void Recuperar() {
        string sqlQuery = "SELECT * FROM teste";
        IDbCommand _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;

        IDataReader reader = _command.ExecuteReader();

        while (reader.Read()) {
            string name = (string)reader["name"];
            int value = (int)reader["score"];

            Debug.Log( "value = " + value + " name = " + name);
        }
    }

    public void uselessButton() { }
}
