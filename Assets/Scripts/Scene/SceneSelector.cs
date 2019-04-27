using System;
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
    public GameObject[] Maps = new GameObject[2];
    private int index = 0;
    public PlayerHealth health;
    public HostageController hostcon;

    public MenuAudioController Audio;

    private void Start()
    {

        //for(int i = 0; i < 4; i++)
        //{
        //  Maps[i].SetActive(false);
        //}
       // StaticClass.GetLevel = "Normal";
        for (int i = 0; i < 3; i++)
        {
            if (!Maps[i].name.Contains(StaticClass.GetMap))
            {
                Maps[i].SetActive(false);
            }
            else
            {
                Maps[i].SetActive(true);
                return;
            }
        }
        


    }

    private void Update()
    {
       if (isDead())
        {
            StaticClass.GetDeadStatus = "dead";
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
            //try
            //{
            //    StaticClass.GetLevel = SelectionText.text.ToString();
            //}
            //catch(Exception e)
            //{
            //    StaticClass.GetLevel = "Normal";
            //}
        }
    }

    public void RightSelection()
    {
        Audio.PlayBtn();
        if (index < listText.Count - 1)
        {
            index++;
            SelectionText.text = listText[index].text;
            //try
            //{
            //    StaticClass.GetLevel = SelectionText.text.ToString();
            //}
            //catch(Exception e)
            //{
            //    StaticClass.GetLevel = "Normal";
            //}
        }
    }

    public void PlayGame()
    {
        StaticClass.GetLevel = SelectionText.text.ToString();
        Audio.PlayBtn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }

    public bool isDead()
    {
        return health.isdead || TimeCounter.timeleft <= 0f;
    }
    public bool isRecurAll()
    {
        return hostcon.isRecurAllHostage();
    }
}
