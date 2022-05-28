using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerMovementScript playerMovementScript;
    private float holdForScare;
    public float lengthOfScare= 2.3f;
    public bool isScaring;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > holdForScare)
        {
            holdForScare = Time.time + lengthOfScare;
            playerAnimator.Play("Scare");
        }else if (Input.GetKey(KeyCode.Q) && Time.time > holdForScare || Input.GetKey(KeyCode.E) && Time.time > holdForScare || Input.GetAxisRaw("Horizontal") != 0 && Time.time > holdForScare || Input.GetAxisRaw("Vertical") != 0 && Time.time > holdForScare)
        {
            playerAnimator.Play("Float");
        }else if (Time.time>holdForScare)
        {
            playerAnimator.Play("Idle");
        }
    }
}
