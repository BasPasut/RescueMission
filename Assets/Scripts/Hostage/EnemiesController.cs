using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesController : MonoBehaviour

{
    public Rigidbody m_Shell;
    public Transform m_FireTransform;  
    public float lookRadius = 10f;
    public AudioManager am;
    private float _timeleft = 0.3f;

    
    

    Transform target;
    NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        print(m_FireTransform.forward);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            
            agent.SetDestination(target.position);
            // am.PlayBackgroundSound();
            



            if(distance <= agent.stoppingDistance)
            { 
                //Attack the target
                //Face the target
                _timeleft -= Time.deltaTime;
                FaceTarget();
                if(_timeleft <= 0.0f)
                {
                    Fire(distance);
                    _timeleft = 0.3f;
                }
            }
        }
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


    private void Fire (float distance)
        {
            // Set the fired flag so only Fire is only called once.
            Debug.Log(m_FireTransform.forward);
            Debug.Log(distance);

            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = distance * m_FireTransform.forward; 

            // Change the clip to the firing clip and play it.
            // m_ShootingAudio.clip = m_FireClip;
            // m_ShootingAudio.Play ();

            // Reset the launch force.  This is a precaution in case of missing button events.
            // m_CurrentLaunchForce = m_MinLaunchForce;
        }



}
