using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : DestroyedSingletonMono<UiInventory>
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

    private List<UiInventory_Item> itemList = new List<UiInventory_Item>();

    private const int inventoryMax = 8;

    public bool IsInventoryFull()
    {
        return itemList.Count >= inventoryMax ? true : false;
    }

    public UiInventory_Item MakeItem(ItemType type)
    {
        UiInventory_Item item = Instantiate<UiInventory_Item>(itemPrefab, grid);
        item.Initialize(null, "열쇠", type);
        return item;
    }

    public void AddItem(ItemType type)
    {
        if (IsInventoryFull() == true)
        {
            Debug.Log("인벤토리가 가득 찼어요!!");
        }
        else
        {
            UiInventory_Item item = MakeItem(type);

            itemList.Add(item);       
        }
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
