using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneTitle : UiSceneBase
{
    public void OnClickStartButton()
    {
        //게임씬으로 변환
        SceneManager.Instance.ChangeScene(SceneType.SceneGame);     
    }

    public void OnClickLoadButton()
    {
        //데이터 로드해서 게임 시작 
    }

    public void OnClickGachaButton()
    {
        //가챠
        SceneManager.Instance.ChangeScene(SceneType.SceneGacha);
    }

    public void OnClickExitButton()
    {
        //게임 종료 (에디터에서는 작동X)
        Application.Quit();
    }

 


}
