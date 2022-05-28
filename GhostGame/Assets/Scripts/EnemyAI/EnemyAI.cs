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
    
    public float posNum;
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

   

    public void PositionRNG()
    {
        posNum = Random.Range(1, 6);
        if(posNum == 1)
        {
            
        }
        if(posNum == 2)
        {

        }
        if(posNum == 3)
        {

        }
        if(posNum == 4)
        {

        }
        if(posNum == 5)
        {

        }
        if(posNum == 6)
        {

        }


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
