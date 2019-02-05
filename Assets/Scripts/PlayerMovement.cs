using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public AudioClip walkingClip;
    public Animator animator;
    private float Speed;

    bool isCrawling = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get the animator
        animator = this.gameObject.GetComponent<Animator>();
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetFloat("Speed", 1f);
                SetFloatAnim(hor * 2f, ver * 2f);
                Speed = 10;
            }
            else
            {
                animator.SetFloat("Speed", 1f);
                SetFloatAnim(hor, ver);
                Speed = 15;
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
        Vector3 playerMovement = new Vector3(hor, 0f, ver)*Speed* Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void SetFloatAnim(float hor, float ver)
    {
        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
    }
}
