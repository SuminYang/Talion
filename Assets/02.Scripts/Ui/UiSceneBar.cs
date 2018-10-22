using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneBar : MonoBehaviour {

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneElevator);
    }
}
