using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DbFileNames
{
    public const string GachaDBName = "Gacha.db";
}

public class GachaData
{
    public string itemName { get; private set; }
    public bool hasItem { get; private set; }
    public string description { get; private set; }

    public GachaData(string itemName, bool hasItem, string description)
    {
        this.itemName = itemName;
        this.hasItem = hasItem;
        this.description = description;
    }
}

public class DialogData
{
    public enum SpeakerPosition
    {
        LEFT,RIGHT
    }

    public string filename { get; private set; }
    public string speaker { get; private set; }
    public string message { get; private set; }
    public SpeakerPosition position { get; private set; }
    public DialogData(string filename, string speaker, string message, SpeakerPosition position) 
    {
        this.filename = filename;
        this.speaker = speaker;
        this.message = message;
        this.position = position;
    }
}


