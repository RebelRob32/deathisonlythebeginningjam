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
            agent.SetDestination(exit.transform.position);
            agent.speed = speed * 5;
        }
    }

  

    IEnumerator ScaredTime()
    {
        isScared = true;
        
        if (isScared == true)
        {
            Vector3 randomDir = Random.insideUnitSphere * range;
            randomDir += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDir, out hit, range, 1);
            Vector3 finalPos = hit.position;
            agent.SetDestination(finalPos);
            agent.speed = speed * 5;
        }
        yield return new WaitForSeconds(4);
        isScared = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

  
}
