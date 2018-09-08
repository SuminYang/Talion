using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNameinput : MonoBehaviour {
    public void OnClickNameOKButton()
    {
        //게임으로 전환
        SceneManager.Instance.ChangeScene(SceneType.SceneGame);
    }
}
