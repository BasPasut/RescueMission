using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAudioController : MonoBehaviour
{
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Btn;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(Win);
    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(Lose);
    }

    public void PlayBtnSound()
    {
        audioSource.PlayOneShot(Btn);
    }
}
