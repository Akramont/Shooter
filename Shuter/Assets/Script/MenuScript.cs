using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{ 

    public void exitPressed()
    {
        Application.Quit();
    }

    public void levelTest()
    {
        SceneManager.LoadScene("LevelTest");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }


}