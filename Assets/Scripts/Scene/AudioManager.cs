using UnityEngine;

/**
*Script for perform a sound after some action
*/
public class AudioManager : MonoBehaviour
{

    public AudioClip Driving;
    public AudioClip BG;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTankDrivingSound()
    {
        audioSource.PlayOneShot(Driving);
    }

    public void PlayBackgroundSound()
    {
        audioSource.PlayOneShot(BG);
    }

   
}