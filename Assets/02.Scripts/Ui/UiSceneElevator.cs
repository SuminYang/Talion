using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneElevator : UiSceneBase
{

    public void OnClickBOneButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneBar);
    }

    public void OnClickOneFButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneAisle);
    }
}
