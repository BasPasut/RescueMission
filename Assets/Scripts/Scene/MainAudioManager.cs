using UnityEngine;

/**
*Script for perform a sound after some action
*/
public class MainAudioManager : MonoBehaviour
{

    public AudioClip Tank_Driving;
    public AudioClip Tank_Idle;
    public AudioClip BG;
    public AudioClip Hostage;
    public AudioClip Bomb;
    public EnemiesController TankMovement;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTankDrivingSound()
    {
        if (TankMovement.getIsMoving())
        {
            audioSource.PlayOneShot(Tank_Driving,0.5f);
        }
        else
        {
            audioSource.Stop();
        }
        Debug.Log(TankMovement.getIsMoving());
    }

    public void PlayTankIdleSound()
    {
        if (!TankMovement.getIsMoving())
        {
            audioSource.PlayOneShot(Tank_Idle,0.5f);
        }
        else
        {
            audioSource.Stop();
        }
        Debug.Log(TankMovement.getIsMoving());
    }

    public void PlayBackgroundSound()
    {
        audioSource.PlayOneShot(BG);
    }

    public void PlayHostageSound()
    {
        audioSource.PlayOneShot(Hostage);
    }

    public void PlayBombSound()
    {
        audioSource.PlayOneShot(Bomb);
    }
   
}