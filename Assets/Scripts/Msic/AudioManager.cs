using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource AudioSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayPlayerAudio(AudioClip clip)
    {
        PlaySound(AudioSource,clip);
    }

    public void PlaySound(AudioSource audioSource, AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
