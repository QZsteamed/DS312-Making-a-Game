using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager; //สตภýปฏ

    public AudioSource audioSource;
    public AudioClip background;
    public AudioClip wheelchair;
    public AudioClip endAudio;

   public void Awake()
    {
        audioManager = this;
    }

    public void WheelchairAudio()
    {
        audioSource.clip = wheelchair;
        audioSource.Play();
    }

    public void WheelchairStop()
    {
        audioSource.clip = wheelchair;
        audioSource.Stop();
    }

    public void BackgroundStop()
    {
        audioSource.clip = background;
        audioSource.Stop();
    }

    public void EndAudio()
    {
        audioSource.clip = endAudio;
        audioSource.Play();
    }
}
