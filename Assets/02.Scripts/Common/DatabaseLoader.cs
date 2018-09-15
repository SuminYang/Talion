using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Mono.Data.SqliteClient;
using UnityEngine.UI;

/// <summary>
/// DB 파일을 읽어오고 정보를 저장
/// </summary>

public class DatabaseLoader
{
    public void LoadAllDatas()
    {
        LoadGachaDB();
    }
    #region DataContainer

    //가챠 데이터
    public List<GachaData> gachaDatas { get; private set; }
    public string GetRandomGachaItem
    {
        get
        {
            if (gachaDatas == null) return null;
            string itemName = gachaDatas[UnityEngine.Random.Range(0, gachaDatas.Count)].itemName;

            UnlockGachaItem(itemName);

            return itemName;
        }
    }

    //대화 데이터

    #endregion


    #region GachaDataLoad
    private void LoadGachaDB()
    {
        gachaDatas = new List<GachaData>();

        string fileName = DbFileNames.GachaDBName;
        IDbCommand dbcmd = null;
        IDbConnection dbcon = null;
        IDataReader reader = null;

        OpenDB(fileName, ref dbcon);
        ReadGachaDB(ref dbcmd, ref dbcon, ref reader);
        CloseDB(ref dbcmd, ref dbcon, ref reader);

    }

    public void OpenDB(string fileName, ref IDbConnection dbcon)
    {
        string filepath;
#if UNITY_EDITOR
        filepath = Application.streamingAssetsPath + "/" + fileName;
#else
       filepath = Application.persistentDataPath + "/" + fileName;
#endif

        if (!File.Exists(filepath))
        {
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + fileName);
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + fileName);
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        //open db connection
        string connection = "URI=file:" + filepath;

        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    }

    public void CloseDB(ref IDbCommand dbcmd, ref IDbConnection dbcon, ref IDataReader reader)
    {
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }

    public void ReadGachaDB(ref IDbCommand dbcmd, ref IDbConnection dbcon, ref IDataReader reader)
    { // Selects a single Item
        string query;
        /////////////////////////////////////////////////////////// 반드시 수정
        query = "SELECT * FROM Gacha";
        ////////////////////////////////////////////////////////// 반드시 수정
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;

        using (reader = dbcmd.ExecuteReader()) // 테이블에 있는 데이터들이 들어간다. 
        {

            while (reader.Read())
            {
                int t = reader.FieldCount;
                gachaDatas.Add(new GachaData(reader.GetString(0), reader.GetBoolean(1), reader.GetString(2)));

            }
        }
    }

    public void UnlockGachaItem(string itemName)
    {

        string Filepath;
#if UNITY_EDITOR
        Filepath = Application.streamingAssetsPath + "/" + DbFileNames.GachaDBName;
#else
       Filepath = Application.persistentDataPath + "/" + DbFileNames.GachaDBName;
#endif

        if (!File.Exists(Filepath))
        {
            Debug.LogWarning("File \"" + Filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + DbFileNames.GachaDBName);

            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DbFileNames.GachaDBName);
            while (!loadDB.isDone) { }
            File.WriteAllBytes(Filepath, loadDB.bytes);
        }
        string connectionString = "URI=file:" + Filepath;
        //  ItemList.Clear();

        // using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())  // EnterSqL에 명령 할 수 있다. 
            {

                //수정
                string ID = itemName;
                string Boolean = "True";

                string sqlQuery = "UPDATE  Gacha  SET " +
                    "HasItem =" + "'" + Boolean + "'"
                    + "WHERE Name = " + "'" + ID + "'";

                // string sqlQuery = "INSERT INTO ItemTable  (Name,Desc) VALUES('죽창','죽창이다.')";


                //string sqlQuery = "DELETE FROM ItemTable Where ID =5";
                // WHere을 붙인 이유는 테이블 전체를 돌기 때문에 해당 아이디만 수정하게 선택한것.
#if UNITY_EDITOR
                Debug.Log(sqlQuery);
#endif
                //UPDATE UserInfo  SET  Money = 11, Scene ='dd', Pos ='0,0,1', Car ='0,0,1'

                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) // 테이블에 있는 데이터들이 들어간다. 
                {
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        //DB재갱신
        LoadGachaDB();
    }

    #endregion
    #region DialogDataLoad
    #endregion

}
