using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reworkedMovement : MonoBehaviour
{
    public float movementSpeed = 10000f;
    public float maxSpeed = 40f;
    public float stoppingSpeed = 6f;
    public float turnSmoothing;
    private float floatingAxis;
    private Vector3 velocity = Vector3.zero;
    private float remappedX;
    private float remappedY;
    private bool isMoving;
    private Rigidbody playerRB;

    private void movementControl()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 0)
        {
            remappedX = 1;
            remappedY = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            remappedX = 1;
            remappedY = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 1)
        {
            remappedX = 1;
            remappedY = -1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            remappedX = 0;
            remappedY = -1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 0)
        {
            remappedX = -1;
            remappedY = -1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            remappedX = -1;
            remappedY = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == -1)
        {
            remappedX = -1;
            remappedY = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            remappedX = 0;
            remappedY = 1;
        }
        else
        {
            remappedX = 0;
            remappedY = 0;
        }
        if (remappedX != 0 && Mathf.Abs(playerRB.velocity.x) < maxSpeed)
        {
            playerRB.AddForce(new Vector3(movementSpeed * remappedX * Time.deltaTime, 0,0));
        }
        //Slowing the character down once the player has stoped attempting to move.
        if (remappedX == 0)
        {
            playerRB.velocity -= new Vector3(playerRB.velocity.x * stoppingSpeed * Time.deltaTime, 0,  0);
        }
        if (remappedY != 0 && Mathf.Abs(playerRB.velocity.z) < maxSpeed)
        {
            playerRB.AddForce(new Vector3(0,0, movementSpeed * remappedY * Time.deltaTime));
        }
        //Slowing the character down once the player has stoped attempting to move.
        if (remappedY == 0)
        {
            playerRB.velocity -= new Vector3(0, 0, playerRB.velocity.z * stoppingSpeed * Time.deltaTime);
        }
        transform.LookAt(Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x+remappedX, transform.position.y+floatingAxis, transform.position.z+remappedY), ref velocity, turnSmoothing*Time.deltaTime));
    }

    private void floatingControl()
    {
        if (Input.GetKey(KeyCode.G) == true && Input.GetKey(KeyCode.E) == true)
        {
            floatingAxis = 0f;
        }
        else if (Input.GetKey(KeyCode.Q) == true)
        {
            floatingAxis = 1f;
        }
        else if (Input.GetKey(KeyCode.E) == true)
        {
            floatingAxis = -1f;
        }
        else
        {
            floatingAxis = 0f;
        }
        if (floatingAxis != 0 && Mathf.Abs(playerRB.velocity.y) < maxSpeed)
        {
            playerRB.AddForce(new Vector3(0, movementSpeed * floatingAxis * Time.deltaTime, 0));
        }
        //Slowing the character down once the player has stoped attempting to move.
        if (floatingAxis == 0)
        {
            playerRB.velocity -= new Vector3(0, playerRB.velocity.y * stoppingSpeed * Time.deltaTime, 0);
        }
    }


    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        movementControl();
        floatingControl();
    }
}