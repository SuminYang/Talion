using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGachaItem : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text ItemName;

    [SerializeField]
    private Text ItemDescription;

    [SerializeField]
    private GameObject descriptionObject;

    [SerializeField]
    private Button button;

    public void Initielize(string name, bool hasItem, string description, Transform descriptionParents)
    {
        icon.sprite = Resources.Load<Sprite>(string.Format("Gacha/{0}", name));

        StartCoroutine(SetDescriptionParent(descriptionParents));

        ItemName.text = name;
        ItemDescription.text = description;

        SetInteractable(hasItem);
    }
    private IEnumerator SetDescriptionParent(Transform tr)
    {
        yield return null;
        descriptionObject.transform.parent = tr;
    }
    public void SetInteractable(bool hasItem)
    {
        if (hasItem == true)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void OnClick()
    {
        descriptionObject.gameObject.SetActive(!descriptionObject.activeSelf);
    }
}
