using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerController : MonoBehaviour
{
    public float durationInSeconds;
    private float rotationPerSecond;
    private float lastRotationHolder = -125f;
    public float lastTick = 0;


    void Start()
    {
        rotationPerSecond = 180f / durationInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTick && lastTick < durationInSeconds+1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -lastRotationHolder);
            lastRotationHolder += rotationPerSecond;
            lastTick += 1;
        }
    }
}
