﻿using System.Collections;
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

    private void Update()
    {
       if (isDead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LeftSelection()
    {
        if (index > 0)
        {
            index--;
            SelectionText.text = listText[index].text;
        }
    }

    public void RightSelection()
    {
        if (index < listText.Count - 1)
        {
            index++;
            SelectionText.text = listText[index].text;
        }
    }

    public void PlayGame()
    {
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
