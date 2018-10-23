using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneElevator : UiSceneBase
{

    public void OnClickB1Button()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneBar);
    }

    public void OnClick1FButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneGame);
    }

    public void OnClick2FButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneAisle);
    }
}
