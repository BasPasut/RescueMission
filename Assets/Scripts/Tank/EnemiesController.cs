using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesController : MonoBehaviour

{
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    private float lookRadius;

    private float _timeleft = 1f;
    private float _timeleftchangepos = 1f;

    private float timeLeftByLevel;

    bool isMoving;

    public MainAudioManager Audio;
    //public GameObject m_player;


    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        

        if (StaticClass.GetLevel == null)
        {
            timeLeftByLevel = 1f;
            lookRadius = 120;
        }

        if (StaticClass.GetLevel.ToString().Contains("Normal"))
        {
            timeLeftByLevel = 1f;
            lookRadius = 120;
        }
        else if (StaticClass.GetLevel.ToString().Contains("Difficult"))
        {
            timeLeftByLevel = 0.6f;
            lookRadius = 150;
        }
        else if (StaticClass.GetLevel.ToString().Contains("Nightmare"))
        {
            timeLeftByLevel = 0.3f;
            lookRadius = 200;
        }
        
        Debug.Log(timeLeftByLevel);
    }

    // Update is called once per frame
    void Update()
    {
        // print(m_FireTransform.forward);
        target = PlayerManager.instance.player.transform;
        //Debug.Log(target.position);
        float distance = Vector3.Distance(target.position, transform.position);
        //Debug.Log("distance " + distance);
        //setIsMoving(false);
        //Audio.PlayTankIdleSound();
        //Debug.Log(distance);

        if (distance <= lookRadius)
        {
            //Debug.Log(distance);
            agent.SetDestination(target.position);
            //setIsMoving(true);
            //Audio.PlayTankDrivingSound();

            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                //Face the target
                _timeleft -= Time.deltaTime;
                FaceTarget();
                if (_timeleft <= 0.0f)
                {
                    Fire(target.position, distance);
                    _timeleft = timeLeftByLevel;
                }
            }
        }
        //else
        //{
        //   System.Random rnd = new System.Random();
        //   _timeleftchangepos -= Time.deltaTime;
        //   if(_timeleftchangepos <= 0.0f)
        //   {
        //       Vector3 v = new Vector3(minusorplus() * rnd.Next(150, 200), 0, minusorplus() * rnd.Next(150, 200));
        //       Debug.Log(v);
        //       agent.SetDestination(v);
        //       _timeleftchangepos = 3f;
        //   }

        //}
    }

    public void setIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    public bool getIsMoving()
    {
        return isMoving;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //int minusorplus()
    //{
    //    System.Random r = new System.Random();
    //    var v = r.Next(0, 2);
    //    if (v == 0)
    //    {
    //        return 1;
    //    }
    //    else
    //    {
    //        return -1;
    //    }


    //}


    private void Fire(Vector3 pos, float distance)
    {
        // Set the fired flag so only Fire is only called once.
        // Debug.Log(m_FireTransform.forward);
        // Debug.Log(pos);



        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;


        shellInstance.useGravity = false;
        Vector3 dir = (pos - m_FireTransform.position).normalized * distance;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = dir;

        // Change the clip to the firing clip and play it.
        // m_ShootingAudio.clip = m_FireClip;
        // m_ShootingAudio.Play ();

        // Reset the launch force.  This /is a precaution in case of missing button events.
        // m_CurrentLaunchForce = m_MinLaunchForce;
    }



}
