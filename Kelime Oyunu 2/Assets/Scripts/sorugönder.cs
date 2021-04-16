using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class sorugönder : MonoBehaviour
{
    public Text sgönder;
    public Text cgönder;
    void Awake()
    {
        veritabanı vt = new veritabanı();
    }

    // Update is called once per frame
    void Start()
    {
     
    }
    public void soru()
    {
        string a = "";
        a = sgönder.GetComponent<Text>().text.ToLower();
        string b = "";
        b = cgönder.GetComponent<Text>().text.ToLower();

        string conn = "URI=file:" + Application.dataPath + "/Sorular.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery =" INSERT INTO sorular (soru,cevap) VALUES('" + a +"','"+b+"') " ;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
    }

    






}
