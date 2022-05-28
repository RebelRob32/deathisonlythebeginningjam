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
    public Transform foundWaypoint;


    public float speed;
    public int index;
    public bool isScared;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(SimulateLife());
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        agent.SetDestination(foundWaypoint.position);
        agent.speed = speed;
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
        yield return new WaitForSeconds(10);
        StartCoroutine(SimulateLife());
    }
   
    public void RunAway()
    {
        if(player.isScaring == true)
        {
            StartCoroutine(ScaredTime());
        }
    }

  

    IEnumerator ScaredTime()
    {
        isScared = true;
        agent.SetDestination(-player.transform.position);
        agent.speed = speed * 2;
        yield return new WaitForSeconds(4);
        isScared = false;
    }
}
