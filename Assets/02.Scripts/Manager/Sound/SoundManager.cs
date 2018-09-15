using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사운드 파일 추가 경로
//Resources 폴더 

//사운드 재생하는 방법
//BGM :  SoundManager.Instance.PlayBGM("BGM이름");
//EFX :  SoundManager.Instance.PlayEFX("효과음이름")

public class SoundManager : SingletonMono<SoundManager>
{
    [SerializeField]
    private AudioSource bgmSource;

    [SerializeField]
    private EfxSound efxPrefab;

    private ObjectPool<EfxSound> efxSoundPool;

    private Dictionary<string, AudioClip> bgmContainer = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> effectContainer = new Dictionary<string, AudioClip>();



    private new void Awake()
    {
        base.Awake();
        LoadSounds();
        MakeEfxSoundPool();
    }
    private void MakeEfxSoundPool()
    {
        efxSoundPool = new ObjectPool<EfxSound>(efxPrefab, 3, this.transform);
    }

    private void LoadSounds()
    {
        AudioClip[] bgmClips = Resources.LoadAll<AudioClip>("Sound/BGM/");
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgmContainer.Add(bgmClips[i].name, bgmClips[i]);
        }

        AudioClip[] efxClips = Resources.LoadAll<AudioClip>("Sound/Effect/");
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
        EfxSound sound = efxSoundPool.GetItem();

        if (sound != null)
        {
            sound.Play(effectContainer[name]);
        }
    }

}
