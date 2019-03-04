using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static int Health = 100;

    public GameObject player;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReducingHealth", 1, 1);
    }

    void ReducingHealth()
    {
        Health -= 20;
        //healthBar.value = Health;
        
        if(Health <= 0)
        {
            player.GetComponent<Animator>().SetTrigger("isDead");
            
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
