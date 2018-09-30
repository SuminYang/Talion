using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMono<DataManager>
{
    public DatabaseLoader dataBaseLoader { get; private set; }

    private new void Awake()
    {
        base.Awake();
        DataLoad();
    }

    private void DataLoad()
    {
        dataBaseLoader = new DatabaseLoader();
        dataBaseLoader.LoadAllDatas();
    }
}
