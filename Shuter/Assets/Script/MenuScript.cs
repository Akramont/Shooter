using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    public void playPressed()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void exitPressed()
    {
        Application.Quit();
    }

    public void levelTest()
    {
        SceneManager.LoadScene("LevelTest");
    }

    public void backLevelSelect()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

}