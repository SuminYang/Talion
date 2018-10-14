using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTitle : UiSceneBase
{
    private void Start()
    {
        PlayBGM();
    }
    private void PlayBGM()
    {
        SoundManager.Instance.PlayBGM("Talion");
    }
    public void OnClickStartButton()
    {  
        SceneManager.Instance.ChangeScene(SceneType.SceneTrigger);
    }

    public void OnClickLoadButton()
    {
        //데이터 로드해서 게임 시작 (뭘 구현 하죵)
    }

    public void OnClickGachaButton()
    {     
        SceneManager.Instance.ChangeScene(SceneType.SceneGacha);
    }

    public void OnClickExitButton()
    {
        //게임 종료 (에디터에서는 작동X)
        Application.Quit();
    }

}
