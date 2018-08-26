using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGachaPopup : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;

    [SerializeField]
    private Button confirmButton;

    [SerializeField]
    private Text itemText;

    public void SetIcon(Sprite sprite)
    {
        itemIcon.sprite = sprite;
    }

    public void FadeImage(float time)
    {
        itemIcon.gameObject.SetActive(true);
        itemIcon.color = new Color(1f, 1f, 1f, 0f);
        iTween.FadeTo(itemIcon.gameObject, 1f, time);
    }

    public void ShowConfirmButton(float time)
    {
        confirmButton.gameObject.SetActive(true);
        confirmButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        confirmButton.enabled = false;
        iTween.FadeTo(confirmButton.gameObject,iTween.Hash("alpha",1f, "time",time, "oncompletetarget",this.gameObject, "oncomplete", "ButtonDirectionOnComplete"));

    }

    public void ButtonDirectionOnComplete()
    {
        confirmButton.enabled = true;
    }

    public void ShowItemInfoText(float time, string itemName)
    {
        itemText.gameObject.SetActive(true);
        itemText.text = itemName;
        itemText.color = new Color(1f, 1f, 1f, 0f);
        iTween.FadeTo(itemText.gameObject, 1f, time);
    }

    public void ResetPopUp()
    {
        confirmButton.gameObject.SetActive(false);
        itemIcon.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);

    }

}
