using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneBase : MonoBehaviour
{
    public void GoTitleButtonClick()
    {
        if (SceneManager.Instance != null)
            SceneManager.Instance.ChangeScene(SceneType.SceneTitle);
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneType.SceneTitle.ToString());
        }
    }

}
