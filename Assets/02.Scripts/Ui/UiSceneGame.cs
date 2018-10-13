using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneGame : UiSceneBase
{
    [SerializeField]
    private GameObject inventory;
    private GameObject Menu;

    public void OnClickInventoryButton()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OnClickMenuButton()
    {
        Menu.SetActive(!inventory.activeSelf);
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
