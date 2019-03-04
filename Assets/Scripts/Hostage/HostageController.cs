using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageController : MonoBehaviour
{
    public Animator HostageAnim;
    public PlayerMovement RescueFin;
    // Start is called before the first frame update
    void Start()
    {
        //Get the animator
        HostageAnim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(RescueFin.isFinished == true)
        {
            HostageAnim.SetBool("isFinish", true);
            if (HostageAnim.GetCurrentAnimatorStateInfo(0).IsName("Finish"))
            {
                HostageAnim.gameObject.SetActive(false);
            }
        }

    }


}
