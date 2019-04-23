using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    // public TextMeshProUGUI HostageLeft;
    public Slider RescueBar;
    public bool isFinished = false;
    public float RescueTime = 10;

    public float Speed;
    private float SpeedbyLevel;
    bool isNearHostage;
    bool isRescusing;
    bool isCrawling = false;
    // int HostageNumber = 5;

    float RescueMax = 10;
    float RescueCurrent;
    public GameObject RescueCanvas;
    public GameObject hostage;

    // Start is called before the first frame update
    void Start()
    {
        //Get the animator
        animator = this.gameObject.GetComponent<Animator>();
        //Debug.Log(StaticClass.GetLevel);

        if (StaticClass.GetLevel == null)
        {
            SpeedbyLevel = 28;
        }

        else if (StaticClass.GetLevel.ToString().Contains("Normal"))
        {
            SpeedbyLevel = 28;
        }
        else if (StaticClass.GetLevel.ToString().Contains("Difficult"))
        {
            SpeedbyLevel = 25;
        }
        else if (StaticClass.GetLevel.ToString().Contains("Nightmare"))
        { 
            SpeedbyLevel = 23;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrawling = true;
            animator.SetFloat("Speed", 0f);
            Speed = 2;

        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isCrawling = false;
            animator.SetFloat("Speed", 0f);
            Speed = 2;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            SetFloatAnim(hor, ver);
            animator.SetFloat("Speed", 1f);
            Speed = SpeedbyLevel;
        }

        if (isNearHostage == true)
        {
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isCPR", true);
                isRescusing = true;
                Speed = 0;
                RescueCanvas.SetActive(true);
                if (RescueTime > 0)
                {
                    isFinished = false;
                    RescueCurrent = Time.deltaTime;
                    RescueTime -= RescueCurrent;
                    RescueBar.value = RescueTime;
                }
                else
                {
                    animator.SetBool("isCPR", false);
                    isFinished = true;
                    // HostageLeft.text = "X" + HostageNumber--;
                }
            }
            else
            {
                animator.SetBool("isCPR", false);
                isRescusing = false;
                RescueCanvas.SetActive(false);
                RescueBar.value = RescueMax;
            }
        }

        animator.SetBool("Crawling", isCrawling);
        animator.SetBool("Moving", ver == 0 ? false : true);
        SetFloatAnim(hor, ver);
        Movement();
    }

    private void Movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void SetFloatAnim(float hor, float ver)
    {
        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name.Contains("Hostage"))
        {
            isNearHostage = true;
            hostage = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Contains("Hostage"))
        {
            isNearHostage = false;
            RescueBar.value = RescueMax;
            RescueTime = RescueMax;
        }
    }
}
