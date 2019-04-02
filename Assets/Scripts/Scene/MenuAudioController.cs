using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    public AudioClip MenuOST;
    public AudioClip Btn;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOST()
    {
        audioSource.PlayOneShot(MenuOST);
    }

    public void PlayBtn()
    {
        audioSource.PlayOneShot(Btn);
    }

}
