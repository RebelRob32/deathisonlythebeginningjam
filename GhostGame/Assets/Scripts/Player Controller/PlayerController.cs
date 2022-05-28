using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats stats;
    public CharacterController controller;
    public Animator anim;
    public Transform camTransform;
    public bool isScaring;


    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
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
        

        controller.Move(velocity * Time.deltaTime);
    }

    public void Scare()
    {
        if (Input.GetKey(KeyCode.Space))
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
}
