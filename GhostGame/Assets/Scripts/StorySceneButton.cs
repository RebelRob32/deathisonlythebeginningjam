using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneButton : MonoBehaviour
{
   public void BeginGame()
    {
        SceneManager.LoadScene("nate's scene");
    }
}
