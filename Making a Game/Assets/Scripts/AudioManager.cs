using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager; //สตภýปฏ

    public AudioSource audioSource;
    public AudioClip background;
    public AudioClip wheelchair;
    public AudioClip goodEndAudio;
    public AudioClip badEndAudio;
    public AudioClip puzzle1, puzzle2, puzzle3, puzzle4;

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

    public void GoodEndAudio()
    {
        audioSource.clip = goodEndAudio;
        audioSource.Play();
    }

    public void BadEndAudio()
    {
        audioSource.clip = badEndAudio;
        audioSource.Play();
    }

    public void puzzleAudio1()
    {
        audioSource.clip = puzzle1;
        audioSource.Play();
    }

    public void puzzleAudio2()
    {
        audioSource.clip = puzzle2;
        audioSource.Play();
    }

    public void puzzleAudio3()
    {
        audioSource.clip = puzzle3;
        audioSource.Play();
    }

    public void puzzleAudio4()
    {
        audioSource.clip = puzzle4;
        audioSource.Play();
    }

    public void puzzleAudio1Stop()
    {
        audioSource.clip = puzzle1;
        audioSource.Stop();
    }

    public void puzzleAudio2Stop()
    {
        audioSource.clip = puzzle2;
        audioSource.Stop();
    }

    public void puzzleAudio3Stop()
    {
        audioSource.clip = puzzle3;
        audioSource.Stop();
    }

    public void puzzleAudio4Stop()
    {
        audioSource.clip = puzzle4;
        audioSource.Stop();
    }
}
