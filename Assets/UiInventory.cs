using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    public enum InventoryState
    {
        None,
        Selecting,
        Using
    }



    private InventoryState state = InventoryState.Using;

    [SerializeField]
    private Transform grid;

    [SerializeField]
    private UiInventory_Item itemPrefab;

    [SerializeField]
    private UiSelectingItem selectingItem;


    public UiInventory_Item MakeItem()
    {
        UiInventory_Item item = Instantiate<UiInventory_Item>(itemPrefab, grid);
        return item;
    }

    private void Update()
    {
        if (state == InventoryState.Using)
        {
            selectingItem.transform.position = Input.mousePosition;

        }
        else
        {
            selectingItem.gameObject.SetActive(false);
        }
    }

}
