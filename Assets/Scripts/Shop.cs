using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
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
        ////Carga el valor de las monedas guardado en las playerprefs
        //int monedas = PlayerPrefs.GetInt("Coins", 0);
        ////Actualiza el texto de las monedas en la tienda
        //coins.text = "Coins: " + monedas;
    }

    public void PurchaseSkin()
    {
        //Carga el valor de las monedas guardado en las playerprefs
        int monedas = PlayerPrefs.GetInt("Coins", 0);

        if (monedas >= skinPrice)
        {
            //Resta el costo del artículo al valor de las monedas
            monedas -= skinPrice;
            //Guarda el nuevo valor de las monedas en las playerprefs
            PlayerPrefs.SetInt("Monedas", monedas);
            //Actualiza el texto de las monedas en la tienda
            coins.text = "Monedas: " + monedas;
            Sprite newSprite = Resources.Load<Sprite>("Skins/" + newSkin.name);
            GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = newSprite;
            //TODO: dar al jugador el artículo comprado
        }
        else
        {
            //TODO: Mostrar mensaje de que el jugador no tiene suficientes monedas para comprar el artículo
        }
    }
}
