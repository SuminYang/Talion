using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneHotelFront : UiSceneBase
{
    private void Start()
    {
        UiDialog.Instance.PlayDialog(0);
    }

    private void Update()
    {
        // check endDialog
        if (UiDialog.Instance.checkEndDialog() )
        {
            Debug.Log("endDialog is true");
            // load Scene....  etc...
            SceneManager.Instance.ChangeScene(SceneType.SceneGame);
        }
    }

}
