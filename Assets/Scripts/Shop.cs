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
        //Obtenemos el total de las monedas ganadas
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            GameManager.instance.totalCoins = PlayerPrefs.GetInt("CoinsAmount");
        }

        //Llamamos a la función que actualiza las monedas en la interfaz
        UpdateCoinsText();
    }

    public void PurchaseSkin(int skinIndex, int skinPrice)
    {
        if (gameManager.coin >= skinPrice)
        {
            gameManager.coin -= skinPrice;
            //Actualiza el skin actual del jugador al skin comprado
            gameManager.currentSkin = skinIndex;

            // Actualiza el valor de PlayerPrefs
            PlayerPrefs.SetInt("CoinsAmount", gameManager.coin);
        }
    }

    public void UpdateCoinsText()
    {
        coins.text = "Coins: " + GameManager.instance.coin.ToString();
    }
}
