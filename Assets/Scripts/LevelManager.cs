using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float finalScore;
    public GameObject finalScreen;

    void Update()
    {
        if (PlayerController.instance.score >= finalScore)
        {
            finalScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
