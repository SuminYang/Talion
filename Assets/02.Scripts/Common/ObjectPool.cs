using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> datas;

    private T prefab;

    private Transform parent;

    public ObjectPool(T prefab, int initNum, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;

        datas = new List<T>();

        for (int i = 0; i < initNum; i++)
        {
            MakeObject();
        }
    }

    private T MakeObject()
    {
        T obj = GameObject.Instantiate<T>(prefab, parent);

        obj.gameObject.SetActive(false);

        datas.Add(obj);
        return obj;
    }

    public T GetItem()
    {
        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i].gameObject.activeSelf == false)
            {
                datas[i].gameObject.SetActive(true);
                return datas[i];
            }
        }

        T newItem = MakeObject();
        newItem.gameObject.SetActive(true);

        return newItem;

    }

}
