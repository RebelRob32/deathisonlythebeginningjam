using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float floatSpeed = 3f;
    public float movementSmoothing = 0.3f;
    public float turnSmoothing = 10f;
    private Vector3 velocity = Vector3.zero;
    private float floatingAxis;
    private float remappedX;
    private float remappedY;

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

        Vector3 targetPosition = new Vector3((remappedX * movementSpeed) + transform.position.x, transform.position.y, (remappedY * movementSpeed) + transform.position.z);
        transform.LookAt(Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, turnSmoothing));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementSmoothing);
    }

    private void floatingControl()
    {
        if (Input.GetKey(KeyCode.G) == true && Input.GetKey(KeyCode.E) == true)
        {
            floatingAxis = 0f;
        }else if (Input.GetKey(KeyCode.Q) == true)
        {
            floatingAxis = 1f;
        }else if (Input.GetKey(KeyCode.E) == true)
        {
            floatingAxis = -1f;
        }else
        {
            floatingAxis = 0f;
        }
        Vector3 floatingTarget = new Vector3(transform.position.x, (floatingAxis * floatSpeed) + transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, floatingTarget, ref velocity, movementSmoothing);
    }

    void Update()
    {
        movementControl();
        floatingControl();
    }
}