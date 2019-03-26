using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HostageController : MonoBehaviour
{
    public Animator HostageAnim;
    public PlayerMovement RescueFin;
    public TextMeshProUGUI HostageLeft;
    int HostageNumber = 5;

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
                // Debug.Log("check point " + HostageLeft );
                
                HostageNumber = HostageNumber - 1;
                HostageLeft.text = "X" + HostageNumber;
            }
            // RescueFin.hostage = null;
            // RescueFin.isFinished = false;
        }

    }
    
    public bool isRecurAllHostage()
    {
        if (HostageNumber == 0)
        {
            return true;
        }
        return false;
    }


}
