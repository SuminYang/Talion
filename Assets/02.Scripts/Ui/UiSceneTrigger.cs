using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneTrigger : MonoBehaviour
{
    public void OnClickTriggerButton()
    {
        //이름 입력창으로 전환
        SceneManager.Instance.ChangeScene(SceneType.SceneNameinput);
    }
}