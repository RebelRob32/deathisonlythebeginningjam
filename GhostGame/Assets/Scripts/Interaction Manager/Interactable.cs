using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Charging
{
    public class Interactable : MonoBehaviour
    {
        public bool isInRange;
        public KeyCode interactKey;
        public GameObject uiIcon;
        public UnityEvent interactAction;
        public EnemyAI enem;
        public PlayerAnimationController player;

     
        void Update()
        {
            if (isInRange)
            {
                uiIcon.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    interactAction.Invoke();
                }
            }else
            {
                uiIcon.SetActive(false);
            }
        }

     

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log("Player is in range");
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                Debug.Log("Player is not in range");
            }
        }
    }

 
}