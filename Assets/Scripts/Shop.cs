using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coins;
    private int coinsAmount = 0;
    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            coinsAmount =PlayerPrefs.GetInt("CoinsAmount");
            Debug.Log(coinsAmount);
            coins.text = coinsAmount.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
