using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScenePlayerRoom : MonoBehaviour {

    public void OnClickArrowButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneAisle);
    }


}
