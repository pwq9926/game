using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundPlayer : MonoBehaviour
{
    private static AudioSource _audioSource;
    public static SoundPlayer _soundPlayer;

    [SerializeField] public AudioClip _backgroundMusic, _oldLady, _alienSound, _crash, _playerDeath, _cryingbaby;

    [SerializeField] private static float explosionFrequency = 0.1f;

    void Start()
    {
        _soundPlayer = FindObjectOfType<SoundPlayer>();
        _audioSource = _soundPlayer.GetComponent<AudioSource>();
    }

    public static void PlayBackgroundMusic()
    {
        _audioSource.clip = _soundPlayer._backgroundMusic;
        _audioSource.Play();
    }

    public static void PlayOldLady()
    {
        _audioSource.clip = _soundPlayer._oldLady;
        _audioSource.Play();
    }
    public static void PlayAlienSound  ()
    {
        _audioSource.clip = _soundPlayer._alienSound;
        _audioSource.Play();
    }
    public static void PlayCrash()
    {
        _audioSource.clip = _soundPlayer._crash;
        _audioSource.Play();
    }

    public static void PlayOneShot(AudioClip clip)
    {
        if (_audioSource == null) return;
        _audioSource.PlayOneShot(clip, 1f);
    }

     public void PlayerDeath()
    {
        PlayOneShot(_soundPlayer._playerDeath);
    }
}
