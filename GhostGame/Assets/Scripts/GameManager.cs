using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text score;
    public GameObject[] humans;
    public GameObject winPanel;
    public GameObject losePanel;
    public float timer;
    public float currentTime;


    public void Awake()
    {
        Time.timeScale = 1;
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        
        humans = GameObject.FindGameObjectsWithTag("Human");
        LoseCondition();
        WinCondition();
        

    }

   
    public void WinCondition()
    {
        int numberOfHumans = humans.Length;
        if(numberOfHumans == 0)
        {
            
            winPanel.SetActive(true);
        }
    }

    public void LoseCondition()
    {
        if (timer <= 0)
        {
            Time.timeScale = 0;
            
            losePanel.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
