using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin = 0;
    public Sprite[] skins;
    public int currentSkin;
    public int totalCoins = 0;
    public Text coinText;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coin.ToString();
    }

    public void AddCoin()
    {
        //Debug.Log("Coin added");
        coin++;
    }

    public void SaveCoins() {
        PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount", 0) + coin);
    }
    
    //public void UpdateTotalCoins(int skinPrice)
    //{
    //    totalCoins += skinPrice;
    //}
}
