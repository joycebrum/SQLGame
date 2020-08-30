using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseStage1 : MonoBehaviour
{
    public TextAsset sqlFile;
    public DataBase database;
    public string urlDataBase;
    // Start is called before the first frame update
    void Start()
    {
        this.database.Connect(this.urlDataBase);
    }

    void OnDestroy()
    {
        Destroy(this.database);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTables()
    {
        database.NonQueryCommand(sqlFile.text);
        Debug.Log("Tabela Criada com Sucesso");
    }

    public void GetAlunos()
    {
        string sqlQuery = "SELECT * FROM Alunos";
        System.Data.IDataReader reader = database.QueryCommand(sqlQuery);

        while (reader.Read())
        {
            string name = (string)reader["nome"];
            string value = (string)reader["matricula"];

            Debug.Log("value = " + value + " name = " + name);
        }
    }

}
