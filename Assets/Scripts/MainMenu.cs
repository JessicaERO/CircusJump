using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("TestRoom");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Salir()
    {
        Application.Quit();
    }
}