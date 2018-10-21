using System.Collections;
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
        UiMenu.SetActive(!inventory.activeSelf);
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
