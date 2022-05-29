using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Human")
        {
            Debug.Log("Exit");
            other.gameObject.SetActive(false);
        }
    }
}
