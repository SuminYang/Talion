﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneGame : UiSceneBase
{
    [SerializeField]
    private GameObject inventory;
    
    [SerializeField]
    private GameObject UiMenu;

    [SerializeField]
    private GameObject Menu;

    [SerializeField]
    private GameObject SaveMenu;

    public void OnClickInventoryButton()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OnClickMenuButton()
    {
        UiMenu.SetActive(!UiMenu.activeSelf);
    }

    public void OnClickBtnContinue()
    {
        UiMenu.SetActive(false);
    }

    public void OnClickBtnGoToTItle()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneTitle);
    }

    public void OnClickBtnGoSave()
    {
        Menu.SetActive(false);
        SaveMenu.SetActive(true);
    }

    public void OnClickBtnSaveTemp()
    {
        Menu.SetActive(true);
        SaveMenu.SetActive(false);
        UiMenu.SetActive(false);
    }

    public void OnClickEmplyoee()
    {
        UiDialog.Instance.PlayDialog(4);
    }

    public void OnClickElevator()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneElevator);
    }

    public void OnClickCleaner()
    {
        UiDialog.Instance.PlayDialog(3);
    }

    public void OnClickSohyun()
    {
        UiDialog.Instance.PlayDialog(11);
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            UiDialog.Instance.PlayDialog(0);
        }
    }
#endif
}
