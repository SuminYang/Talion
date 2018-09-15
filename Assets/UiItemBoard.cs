using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItemBoard : MonoBehaviour
{
    [SerializeField]
    private Transform itemParents;
    [SerializeField]
    private Transform descriptionParents;
    [SerializeField]
    private UiGachaItem itemPrefab;
 

    private Dictionary<string, UiGachaItem> itemList = new Dictionary<string, UiGachaItem>();

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        List<GachaData> gachaDatas = DataManager.Instance.dataBaseLoader.gachaDatas;
        if (gachaDatas != null)
        {
            for (int i = 0; i < gachaDatas.Count; i++)
            {
                UiGachaItem item = MakeItem(gachaDatas[i].itemName, gachaDatas[i].hasItem, gachaDatas[i].description);
                itemList.Add(gachaDatas[i].itemName, item);
            }
        }
    }

    private UiGachaItem MakeItem(string name, bool hasItem, string description)
    {
        UiGachaItem item = Instantiate(itemPrefab, itemParents);

        item.Initielize(name, hasItem, description, descriptionParents);

        return item;
    }

    public void UpdateItemInfo(string itemName)
    {
        if (itemList == null && itemList.ContainsKey(itemName) == false) return;
        itemList[itemName].SetInteractable(true);
    }



}
