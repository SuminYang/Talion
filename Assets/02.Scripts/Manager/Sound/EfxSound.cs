using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfxSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public void Play(AudioClip clip, float volume = 1f)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            this.gameObject.SetActive(false);
        }
    }

}
