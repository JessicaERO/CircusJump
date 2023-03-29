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
        coinText.text = PlayerPrefs.GetInt("CoinsAmount", 0).ToString();
    }

    public void AddCoin()
    {
        coin++;
    }

    //public void UpdateTotalCoins(int skinPrice)
    //{
    //    totalCoins += skinPrice;
    //}
}
