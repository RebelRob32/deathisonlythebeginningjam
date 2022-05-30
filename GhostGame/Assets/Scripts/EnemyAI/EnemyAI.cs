using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator anim;
    public PlayerController player;
    public NavMeshAgent agent;
    public GameObject[] waypoints;
    public GameObject currentWaypoint;
    public GameObject[] hidingSpots;
    public GameObject currentHidingSpot;
    public GameObject exit;
    public Transform foundWaypoint;
    public Transform foundHidingSpot;


    public float speed;
    public float fearlevel;
    public float range;
    public int index;
    public bool isScared;
    public bool playerIsInRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        hidingSpots = GameObject.FindGameObjectsWithTag("Hiding");
        agent = GetComponent<NavMeshAgent>();
        exit = GameObject.FindWithTag("Exit");
        anim = GetComponent<Animator>();
        StartCoroutine(SimulateLife());
        fearlevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {   
        RunAway();  
    }


    public void PositionRNG()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
        index = Random.Range(0, waypoints.Length);
        currentWaypoint = waypoints[index];

        foundWaypoint = currentWaypoint.transform;
    }

    IEnumerator SimulateLife()
    {
        PositionRNG();
        if (gameObject.name == "HumanChild" || gameObject.name == "HumanChildGirl")
        {
            anim.Play("HumanChild_Walk");
        }
        else
        {
            anim.Play("Adulwalk");
        }
        agent.SetDestination(foundWaypoint.position);
        agent.speed = speed;
        yield return new WaitForSeconds(30);
        StartCoroutine(SimulateLife());
    }
   
    public void RunAway()
    {
        if(player.isScaring == true && player.closestHuman != null && playerIsInRange == true)
        {
            StartCoroutine(ScaredTime());
            fearlevel += 25f;
        }
        else
        {
            return;
        }

        if(fearlevel >= 200f)
        {
            if (gameObject.name == "HumanChild" || gameObject.name == "HumanChildGirl")
            {
                anim.Play("HumanChild_Frightened");
            }
            else
            {
                anim.Play("AdultFrightened");
            }
            agent.SetDestination(exit.transform.position);
            agent.speed = speed * 5;
        }
    }

  

    IEnumerator ScaredTime()
    {
        isScared = true;
        
        if (isScared == true)
        {
            if (gameObject.name == "HumanChild" || gameObject.name == "HumanChildGirl")
            {
                anim.Play("HumanChild_Afraid");
            }
            else
            {
                anim.Play("AdultAfraid");
            }
            index = Random.Range(0, hidingSpots.Length);
            currentHidingSpot = hidingSpots[index];

            foundHidingSpot = currentHidingSpot.transform;
            agent.SetDestination(foundHidingSpot.transform.position);
            agent.speed = speed * 2;
        }
        yield return new WaitForSeconds(15);
        isScared = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

  
}
