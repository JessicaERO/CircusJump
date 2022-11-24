using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
