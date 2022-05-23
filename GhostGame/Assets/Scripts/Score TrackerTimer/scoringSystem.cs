using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    private int currentScore = 0;

    public void scoreCalc(int scoreAdded)
    {
        currentScore += scoreAdded;
    }

    void Update()
    {
        scoreTxt.text = "Score: " + currentScore.ToString();
    }
}