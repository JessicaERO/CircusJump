using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI coins;
    private int coinsAmount;
    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            PlayerPrefs.GetInt("CoinsAmount", coinsAmount);
            Debug.Log(coinsAmount);
            coins.text = coinsAmount.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
