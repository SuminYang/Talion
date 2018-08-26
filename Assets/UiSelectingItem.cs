using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSelectingItem : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;

    public void SetitemIcon(Sprite sprite)
    {
        itemIcon.sprite = sprite;
    }

}
