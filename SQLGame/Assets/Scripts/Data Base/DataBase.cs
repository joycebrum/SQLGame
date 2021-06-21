using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class DataBase : MonoBehaviour
{
    //path just to be a test database. This path can be configured
    private string urlDataBase = ""; 
    private IDbConnection connection;
    
    public void OnDestroy()
    {
        connection.Close();
    }

    public void CloseConnection()
    {
        connection.Close();
    }

    public void Connect(string urlDataBase)
    {
        this.urlDataBase = urlDataBase;
        connection = new SqliteConnection(urlDataBase);
        connection.Open();
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
