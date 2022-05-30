using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public int score;
    public GameObject[] humans;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;
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

        timerText.text = "Time Left: " + Mathf.Round(timer);
        scoreText.text = "Score: " + score;
        humans = GameObject.FindGameObjectsWithTag("Human");
        LoseCondition();
        WinCondition();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausePanel != null)
            {
                bool isActive = pausePanel.activeSelf;
                pausePanel.SetActive(!isActive);
            }
            if (pausePanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
           
        }
    }

    public void AddPoints()
    {
        int numberofHumans = humans.Length;
        
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
        SceneManager.LoadScene("Main Menu");
    }
}
