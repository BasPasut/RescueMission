using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class TimeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timeleft = 300f;
    public TextMeshProUGUI timecounterbar;
    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        float minutes = Mathf.Floor(timeleft / 60);
        float seconds = Mathf.Floor(timeleft % 60);
        timecounterbar.text = minutes + "." + seconds;


        //Debug.Log(minutes+":"+ seconds);
    }

}
