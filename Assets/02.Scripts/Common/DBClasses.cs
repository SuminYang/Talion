using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DbFileNames
{
    public const string GachaDBName = "Gacha.DB";
}

public class GachaData
{
    public string itemName { get; private set; }
    public bool hasItem { get; private set; }
    public string description { get; private set; }

    public GachaData(string itemName, bool hasItem,string description)
    {
        this.itemName = itemName;
        this.hasItem = hasItem;
        this.description = description;
    }
}


