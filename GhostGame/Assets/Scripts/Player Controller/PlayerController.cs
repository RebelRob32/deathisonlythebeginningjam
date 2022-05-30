using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats stats;
    public CharacterController controller;
    public Animator anim;
    public Transform camTransform;
    public GameObject[] humans;
    public GameObject closestHuman;

    public bool isScaring;
    public bool inRange;


    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        humans = GameObject.FindGameObjectsWithTag("Human");
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        closestHuman = GetHumansInRange();
        GetClosestHuman();
        Scare();
    }
    public void FixedUpdate()
    {
        MovePlayer();   
    }

    public void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        direction = Quaternion.AngleAxis(camTransform.rotation.eulerAngles.y, Vector3.up) * direction;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref stats.turnSmoothVelocity, stats.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        Vector3 velocity = direction * stats.speed;
        

        controller.SimpleMove(velocity * Time.deltaTime);
    }

    public GameObject GetHumansInRange()
    {
        humans = GameObject.FindGameObjectsWithTag("Human");

        float closestDist = Mathf.Infinity;
        GameObject holder = null;

        foreach(GameObject human in humans)
        {
            float currentdist;
            currentdist = Vector3.Distance(transform.position, human.transform.position);
            if(currentdist < closestDist)
            {
                closestDist = currentdist;
                holder = human;
            }
        }
        return holder; 
    }
    public void GetClosestHuman()
    {
        if(closestHuman != null)
        {
            float dist = Vector3.Distance(transform.position, closestHuman.transform.position);
            if(dist <= stats.range)
            {
                closestHuman.GetComponent<EnemyAI>().playerIsInRange = true;
                inRange = true;
            }
            else
            {
                closestHuman.GetComponent<EnemyAI>().playerIsInRange = false;
                inRange = false;
            }
        }
    }
 
    public void Scare()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            anim.SetBool("isScaring", true);
            isScaring = true;
        }
        else
        {
            anim.SetBool("isScaring", false);
            isScaring = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stats.range);
    }
}
