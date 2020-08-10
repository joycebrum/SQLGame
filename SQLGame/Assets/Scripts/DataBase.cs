using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class DataBase : MonoBehaviour
{
    //path just to be a test database. This path can be configured
    public string urlDataBase = "URI=file:MasterSQLite.db"; 
    private IDbConnection connection;

    public void Start()
    {
        connection = new SqliteConnection(urlDataBase);
        connection.Open();
    }
    public void OnDestroy()
    {
        connection.Close();
    }

    public void NonQueryCommand(string sql)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }

    public IDataReader QueryCommand(string query)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = query;
        return command.ExecuteReader();
    }
}
