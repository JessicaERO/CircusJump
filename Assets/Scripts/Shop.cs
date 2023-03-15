using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{  
    public GameManager gameManager;
    public Text coins;
    private int coinsAmount = 0;
    public int skinPrice;
    public Sprite newSkin;
  
    void Start()
    {


        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            coinsAmount =PlayerPrefs.GetInt("CoinsAmount");
            Debug.Log(coinsAmount);
            coins.text = coinsAmount.ToString();
        }
    }

    public void PurchaseSkin(int skinIndex, int skinPrice)
    {
        if (gameManager.coin >= skinPrice)
        {
            gameManager.coin -= skinPrice;
            //Actualiza el skin actual del jugador al skin comprado
            gameManager.currentSkin = skinIndex; 
        }
    }
}
