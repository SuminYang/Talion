using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneAisle : UiSceneBase

{

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneElevator);
    }

    public void OnClickRoomButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.ScenePlayerRoom);
    }

    public void OnClickBeom()
    {
        UiDialog.Instance.PlayDialog(7);
    }

    public void OnClickPublic()
    {
        UiDialog.Instance.PlayDialog(8);
    }
}
