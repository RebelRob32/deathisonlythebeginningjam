using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameManager gm;
    public float points;

    public void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Human")
        {
            Debug.Log("Exit");
            other.gameObject.SetActive(false);
            
            
        }
    }
}
