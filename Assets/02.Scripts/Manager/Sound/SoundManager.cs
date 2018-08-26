using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMono<SoundManager>
{
    [SerializeField]
    private AudioSource bgmSource;

    [SerializeField]
    private EfxSound efxPrefab;

    private Dictionary<string, AudioClip> bgmContainer = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> effectContainer = new Dictionary<string, AudioClip>();
    
    private void Awake()
    {
        LoadSounds();
    }

    private void LoadSounds()
    {
        AudioClip[] bgmClips = Resources.LoadAll<AudioClip>("BGM/");
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgmContainer.Add(bgmClips[i].name, bgmClips[i]);
        }

        AudioClip[] efxClips = Resources.LoadAll<AudioClip>("Effect/");
        for (int i = 0; i < efxClips.Length; i++)
        {
            effectContainer.Add(efxClips[i].name, efxClips[i]);
        }
    }

    //BGM 재생
    public void PlayBGM(string name)
    {
        if (bgmContainer.ContainsKey(name) == false)
        {
            Debug.LogErrorFormat("BGM {0} is not exist");
        }

        //BGM 재생
        bgmSource.clip = bgmContainer[name];
        bgmSource.Play();
    }

    //효과음 재생
    public void PlayEFX(string name)
    {
        if (effectContainer.ContainsKey(name) == false)
        {
            Debug.LogErrorFormat("effect {0} is not exist");
        }

        //이펙트 재생
    }

}
