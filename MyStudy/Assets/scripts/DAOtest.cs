using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DAOtest : MonoBehaviour {

	private SQLite_DAO sql;

	// Use this for initialization
	void Start () {
		//sql = new SQLite_DAO("URL=file:" + Application.persistentDataPath + "/write_ache.db");
		sql = new SQLite_DAO("Data Source=./write_ache.db");
		//创建名为table1的数据表
		sql.CreateTable("table1",new string[]{"ID","Direction","Degree"},new string[]{"INTEGER","TEXT","TEXT"});

		//插入两条数据
		sql.InsertValues("table1",new string[]{"'1'","up","High"});
		sql.InsertValues("table1",new string[]{"'2'","down","Low"});


		//读取整张表
		SqliteDataReader reader = sql.ReadFullTable ("table1");
		while(reader.Read()) 
		{
			//读取ID
			Debug.Log(reader.GetInt32(reader.GetOrdinal("ID")));
			//读取Name
			Debug.Log(reader.GetString(reader.GetOrdinal("Direction")));
			//读取Age
			Debug.Log(reader.GetInt32(reader.GetOrdinal("Degree")));

		}

		//关闭数据库连接
		sql.CloseConnection();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
