using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneBar : UiSceneBase {

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneElevator);
    }

    public void OnClickMan()
    {
        UiDialog.Instance.PlayDialog(5);
    }

    public void OnClickHyunbi()
    {
        UiDialog.Instance.PlayDialog(10);
    }

    public void OnClickSubin()
    {
        UiDialog.Instance.PlayDialog(9);
    }
}
