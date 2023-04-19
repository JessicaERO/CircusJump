using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public float finalScore;
    public GameObject finalScreen;
    public Event winCondition;

    void Update()
    {
        if (PlayerController.instance.score >= finalScore)
        {
            finalScreen.SetActive(true);
            Time.timeScale = 0;
            winCondition.Ocurred(gameObject);
        }
    }
}
