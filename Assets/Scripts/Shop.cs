using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coins;
    private int coinsAmount = 0;
    public int articlePrice;
    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            coinsAmount =PlayerPrefs.GetInt("CoinsAmount");
            Debug.Log(coinsAmount);
            coins.text = coinsAmount.ToString();
        }
        ////Carga el valor de las monedas guardado en las playerprefs
        //int monedas = PlayerPrefs.GetInt("Coins", 0);
        ////Actualiza el texto de las monedas en la tienda
        //coins.text = "Coins: " + monedas;
    }

    public void PurchaseArticle()
    {
        //Carga el valor de las monedas guardado en las playerprefs
        int monedas = PlayerPrefs.GetInt("Coins", 0);

        if (monedas >= articlePrice)
        {
            //Resta el costo del artículo al valor de las monedas
            monedas -= articlePrice;
            //Guarda el nuevo valor de las monedas en las playerprefs
            PlayerPrefs.SetInt("Monedas", monedas);
            //Actualiza el texto de las monedas en la tienda
            coins.text = "Monedas: " + monedas;

            //TODO: dar al jugador el artículo comprado
        }
        else
        {
            //TODO: Mostrar mensaje de que el jugador no tiene suficientes monedas para comprar el artículo
        }
    }
}
