using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static bool dontDestroyOnLoad = true;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                SetInstance();
            }

            return instance;
        }
    }

    private static void SetInstance()
    {
        instance = FindObjectOfType(typeof(T)) as T;

        if (instance == null)
        {
            Debug.LogErrorFormat("CustomLog : There is no active {0} in this scene", typeof(T));
        }
        else
        {
            DontDestroyOnLoad(instance.gameObject);
        }
    }


}

