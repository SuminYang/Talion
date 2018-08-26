using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//씬 추가될때마다 여기에 enum값 추가 해주셔야 되고 이름은 추가하신 씬 이름과 같아야 합니다.
public enum SceneType
{
    SceneTitle, SceneGame , SceneGacha
}

public class SceneManager : SingletonMono<SceneManager>
{
    [SerializeField]
    private Image fadeImage;

    //값을 에디터 인스펙터에서 조절하시면 전환되는 속도를 조절하실수 있습니다. 
    //디폴트는 1초 입니다. (ex 2로 하면 전환속도가 2배 되고 0.5로 하시면 전환속도가 0.5초가 됩니다)
    [SerializeField]
    private float fadeSpeed = 1f;

    private SceneType currentScene = SceneType.SceneTitle;

    private Coroutine routine;


    //어떤 스크립트에서든 씬을 변경하고 싶으실때
    //SceneManager.Instance.ChangeScene(SceneType.원하시는 씬); 
    //이런식으로 호출하면 씬이 전환됩니다.    
    public void ChangeScene(SceneType type)
    {      
        if (routine != null)
        {
            Debug.LogErrorFormat("Now scene changing");
            return;
        }
        routine = StartCoroutine(ChangeSceneRoutine(type));
    }

    IEnumerator ChangeSceneRoutine(SceneType type)
    {
        currentScene = type;

        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(type.ToString());

        alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
        routine = null;  
    }



}
