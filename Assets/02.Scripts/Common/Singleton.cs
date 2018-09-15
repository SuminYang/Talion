using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//씬이 전환돼도 살아있음 (SceneManager,SoundManager 등등 모든 씬에서 사용하는 애들)
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
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
            SetInstance();
    }
}

//씬이 전환돼면 사라짐 (SceneManager,SoundManager 등등 모든 씬에서 사용하는 애들)
public class DestroyedSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static bool dontDestroyOnLoad = true;

    private void Awake()
    {
        instance = this as T;
    }

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
        instance = FindObjectsOfTypeAll(typeof(T)) as T;
    }
}


