using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItem : MonoBehaviour, IPointerDownHandler
{
    private ItemType itemType;
    public void Initialize(ItemType type)
    {
        itemType = type;
    }
    public void GetItemToInventory()
    {
        if (UiInventory.Instance.IsInventoryFull() == true)
        {
            Debug.Log("인벤토리가 가득 찼어요");
            return;
        }

        UiInventory.Instance.AddItem(itemType);

        Destroy(this.gameObject);
    }



    public void OnPointerDown(PointerEventData eventData)
    {     
        GetItemToInventory();
    }

  
}
