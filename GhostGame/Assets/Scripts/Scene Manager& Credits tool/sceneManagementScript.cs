using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagementScript : MonoBehaviour
{
    [SerializeField] private string buttonOneTargetSceneName;
    [SerializeField] private string buttonTwoTargetSceneName;
    [SerializeField] private string buttonThreeTargetSceneName;
    [SerializeField] private string buttonFourTargetSceneName;
    [SerializeField] private string buttonFiveTargetSceneName;
    public void buttonOne()
    {
        SceneManager.LoadScene(buttonOneTargetSceneName);
    }
    public void buttonTwo()
    {
        SceneManager.LoadScene(buttonTwoTargetSceneName);
    }
    public void buttonThree()
    {
        SceneManager.LoadScene(buttonThreeTargetSceneName);
    }
    public void buttonFour()
    {
        SceneManager.LoadScene(buttonFourTargetSceneName);
    }
    public void buttonFive()
    {
        SceneManager.LoadScene(buttonFiveTargetSceneName);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("The Game was Quit.");
    }
}
