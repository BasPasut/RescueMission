using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageController : MonoBehaviour
{
    public Animator HostageAnim;
    public PlayerMovement RescueFin;

    Dictionary<string, int> hash = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        //Get the animator
        // HostageAnim = this.gameObject.GetComponent<Animator>();
        // Debug.Log(HostageAnim);
    }

    void Update()
    {
        if (RescueFin.isFinished == true)
        {
            HostageAnim = RescueFin.hostage.GetComponent<Animator>();
            HostageAnim.SetBool("isFinish", true);
            if (HostageAnim.GetCurrentAnimatorStateInfo(0).IsName("Finish"))
            {
                HostageAnim.gameObject.SetActive(false);
                RescueFin.isFinished = false;
                RescueFin.RescueTime = 10;
            }
            // RescueFin.hostage = null;
            // RescueFin.isFinished = false;
        }

    }


}
