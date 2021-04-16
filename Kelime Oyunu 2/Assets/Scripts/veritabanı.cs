using Mono.Data.Sqlite; 
using System.Data;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class veritabanı : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        dataReader();
    }
    public List <Slotlar> dataReader()
    {

    string conn = "URI=file:" + Application.dataPath + "/Sorular.db"; //Path to database.
     IDbConnection dbconn;
     dbconn = (IDbConnection) new SqliteConnection(conn);
     dbconn.Open(); //Open connection to the database.
     IDbCommand dbcmd = dbconn.CreateCommand();
     string sqlQuery = "SELECT soru,cevap " + "FROM sorular";
     dbcmd.CommandText = sqlQuery;
     IDataReader reader = dbcmd.ExecuteReader();


     List<Slotlar> slotlist = new List <Slotlar>();
     while (reader.Read())
     {
         Slotlar slot = new Slotlar();
         slot.soru = reader.GetString(0);
         slot.cevap = reader.GetString(1);
         slotlist.Add(slot);       
         Debug.Log( "soru= "+slot.soru+"  cevap ="+slot.cevap);
     }
     reader.Close();
     reader = null;
     dbcmd.Dispose();
     dbcmd = null;
     dbconn.Close();
     dbconn = null;
     return slotlist;
 }
    }
 

