using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneNameinput : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;

    private void ChangeScene()
    {
        //게임으로 전환
        SceneManager.Instance.ChangeScene(SceneType.SceneGame);
    }

    public void OnClickNameOKButton()
    {
        ChangeScene();
    }

    public void OnValueChanged(string name)
    {
        PlayerPrefs.SetString(Constants.NickNameKey, inputField.text);
    }
}
