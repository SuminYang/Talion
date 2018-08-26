using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory_Item : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;

    [SerializeField]
    private Text descriptionText;

    private ItemType itemType;

    public void Initialize(Sprite sprite, string itemDescription, ItemType type)
    {
        itemIcon.sprite = sprite;

        descriptionText.text = itemDescription;

        itemType = type;
    }

}
