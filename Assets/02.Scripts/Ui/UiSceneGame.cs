using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneGame : UiSceneBase
{
    [SerializeField]
    private GameObject inventory;
    private GameObject Menu;

    [SerializeField]
    private UiDialog uiDialog;

    public void PlayDialog(int index)
    {
        if (uiDialog == null) return;
        uiDialog.PlayDialog(index);
    }

    public void OnClickInventoryButton()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OnClickMenuButton()
    {
        Menu.SetActive(!inventory.activeSelf);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayDialog(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayDialog(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayDialog(1);
        }



    }
}
