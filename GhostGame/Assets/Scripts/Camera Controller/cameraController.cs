using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Vector3 currentPos;
    public Transform transOfPlayer; 

    // Update is called once per frame
    void Update()
    {
        currentPos = transOfPlayer.position;
        transform.position = currentPos;
    }
}
