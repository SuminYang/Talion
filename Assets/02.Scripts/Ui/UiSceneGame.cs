using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneGame : UiSceneBase
{
    [SerializeField]
    private UiInventory uiInventory;
    public void OnClickInventoryButton()
    {
        uiInventory.gameObject.SetActive(!uiInventory.gameObject.activeSelf);
    }

}
