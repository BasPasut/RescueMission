using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



    public void Restart() => Application.LoadLevel(1);

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
