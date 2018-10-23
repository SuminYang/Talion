using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfxSound : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource audioSource;

    public void Play(float volume = 1f)
    {
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
