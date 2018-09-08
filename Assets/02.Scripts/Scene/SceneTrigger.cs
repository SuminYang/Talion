using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    public void OnClickTriggerButton()
    {
        SceneManager.Instance.ChangeScene(SceneType.SceneNameinput);
    }
}
