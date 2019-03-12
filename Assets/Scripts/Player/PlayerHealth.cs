using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public static int Health = 100;
    public bool isdead = false;
    public GameObject player;
    public TextMeshProUGUI  healthBar;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("ReducingHealth", 1, 1);
    }

    public void ReduceHealth()
    {
        if (!isdead)
        {    Health -= 20;
        // Debug.Log(Health);
        
            healthBar.text = Health.ToString();
        }
        if(Health <= 0)
        {   
            isdead = true;
            player.GetComponent<Animator>().SetTrigger("isDead");
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
