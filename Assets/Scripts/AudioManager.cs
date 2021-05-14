using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(AudioListener))]
public class AudioManager : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        Events.FXPlayed += PlayFX;
    }

    private void PlayFX(AudioClip clip)
    {
        aud.PlayOneShot(clip, aud.volume);
    }

    private void OnDestroy()
    {
        Events.FXPlayed -= PlayFX;
    }
}
