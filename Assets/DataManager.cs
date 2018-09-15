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

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dataBaseLoader.UnlockGachaItem("범이의손목보호대1");
        }
    }
#endif
}
