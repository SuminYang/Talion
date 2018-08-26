﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneGame : UiSceneBase
{
    [SerializeField]
    private GameObject inventory;

    public void OnClickInventoryButton()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

}
