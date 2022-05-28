using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerController player;
    public NavMeshAgent agent;
    public GameObject[] movePosition;
    public GameObject currentPosition;

    public float speed;
    public int index;
    public bool isScared;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        PositionRNG();
    }


    public void PositionRNG()
    {
        movePosition = GameObject.FindGameObjectsWithTag("Waypoint");
        index = Random.Range(0, movePosition.Length);
        currentPosition = movePosition[index];

        agent.SetDestination(currentPosition.transform.position * Time.deltaTime * speed);


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
        
        yield return new WaitForSeconds(4);
        isScared = false;
    }
}
