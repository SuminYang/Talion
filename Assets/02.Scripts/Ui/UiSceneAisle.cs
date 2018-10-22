using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneAisle : MonoBehaviour {

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneElevator);
    }

    public void OnClickRoomButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.ScenePlayerRoom);
    }
}
