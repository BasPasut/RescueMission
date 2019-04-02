using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{

    public GameObject WinText;
    public GameObject LoseText;

    public EndAudioController Audio;

    // Start is called before the first frame update
    void Start()
    {
         Debug.Log(StaticClass.CrossSceneInformation);
        if (StaticClass.CrossSceneInformation.Equals("dead"))
        {
            WinText.SetActive(false);
            LoseText.SetActive(true);
            Audio.PlayLoseSound();
        }
        else
        {
            WinText.SetActive(true);
            LoseText.SetActive(false);
            Audio.PlayWinSound();
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }



    public void Restart()
    {
        Application.LoadLevel(1);
        Audio.PlayBtnSound();
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
        Audio.PlayBtnSound();
    }

    public void ExitGame()
    {
        Application.Quit();
        Audio.PlayBtnSound();
    }
}
