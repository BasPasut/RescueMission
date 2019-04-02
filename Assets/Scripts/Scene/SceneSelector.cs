using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSelector : MonoBehaviour
{
    public TextMeshProUGUI SelectionText;
    public List<TextMeshProUGUI> listText = new List<TextMeshProUGUI>();
    private int index = 0;
    public PlayerHealth health;
    public HostageController hostcon;

    public MenuAudioController Audio;

    private void Update()
    {
       if (isDead())
        {
            StaticClass.CrossSceneInformation = "dead";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LeftSelection()
    {
        Audio.PlayBtn();
        if (index > 0)
        {
            index--;
            SelectionText.text = listText[index].text;
        }
    }

    public void RightSelection()
    {
        Audio.PlayBtn();
        if (index < listText.Count - 1)
        {
            index++;
            SelectionText.text = listText[index].text;
        }
    }

    public void PlayGame()
    {
        Audio.PlayBtn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool isDead()
    {
        return health.isdead;
    }
    public bool isRecurAll()
    {
        return hostcon.isRecurAllHostage();
    }
}
