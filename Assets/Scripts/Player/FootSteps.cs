using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float playRate;
    private float lastPlayTime;

    private void Update()
    {
        if (_rigidbody2D.velocity.magnitude > 0 && Time.time-lastPlayTime>playRate)
        {
            Play();
        }
    }

    void Play()
    {
        lastPlayTime = Time.time;
        AudioClip clipToPlay = _audioClips[Random.Range(0,_audioClips.Length)];
        _audioSource.PlayOneShot(clipToPlay);
        
    }
}
