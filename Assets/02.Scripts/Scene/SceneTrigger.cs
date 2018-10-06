using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    public void OnClickTriggerButton()
    {
        //설정된 닉네임이 있으면?
        if (PlayerPrefs.HasKey(Constants.NickNameKey) == true)
        {
            //게임으로 전환
            SceneManager.Instance.ChangeScene(SceneType.SceneGame);
        }
        else
        {
            SceneManager.Instance.ChangeScene(SceneType.SceneNameinput);
        }
    }
}
