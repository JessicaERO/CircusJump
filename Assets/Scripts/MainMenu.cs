using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

    public void startGame()
    {
        SceneManager.LoadScene("InfiniteGame");
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

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }

    public void Level7()
    {
        SceneManager.LoadScene("Level7");
    }

    public void Level8()
    {
        SceneManager.LoadScene("Level8");
    }

    public void Level9()
    {
        SceneManager.LoadScene("Level9");
    }

    public void Level10()
    {
        SceneManager.LoadScene("Level10");
    }

    public void GoToComicMenu()
    {
        SceneManager.LoadScene("ComicMenu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public Text higschoreText;

    void Start()
    {
        //Para que la pantalla no se apague mientras juegas
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        higschoreText.text = "Highscore: " + DataBaseManager.LoadHighscore().ToString();
    }
}
