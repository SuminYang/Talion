using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameItemManager : DestroyedSingletonMono<IngameItemManager>
{
    [SerializeField]
    private DroppedItem itemPrefab;

    public void SpawnItem(Vector3 position, ItemType type)
    {
        DroppedItem item = MakeItem(type);
        item.transform.position = position;
    }

    private DroppedItem MakeItem(ItemType type)
    {
        DroppedItem item = Instantiate(itemPrefab, this.transform);

        item.Initialize(type);

        return item;
    }

    //아이템 생성 예시
    public void SpawnKeyItem()
    {
        SpawnItem(Vector3.zero, ItemType.Key);
    }


    //테스트 코드
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnKeyItem();
        }
    }
#endif
}
