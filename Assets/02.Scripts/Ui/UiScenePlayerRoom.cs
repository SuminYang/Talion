using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScenePlayerRoom : UiSceneBase {

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneAisle);
    }

    public void OnClickColleague()
    {
        UiDialog.Instance.PlayDialog(6);
    }
}
