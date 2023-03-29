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

    public int skinCount = 4;
    public Button[] skinButtons;
    public Text[] skinButtonTexts;
    public int selectedSkinIndex = 1;

    void Start()
    {
        //BORRAR ESTA LINEA + PLAYERPREFS
        PlayerPrefs.SetInt("CoinsAmount", 999);

        //Obtenemos el total de las monedas ganadas
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            GameManager.instance.totalCoins = PlayerPrefs.GetInt("CoinsAmount");
        }

        //Llamamos a la función que actualiza las monedas en la interfaz
        UpdateCoinsText();

        LoadSelectedSkinIndex();
        UpdateSkinButtons();
    }

    public void PurchaseSkin(int skinIndex, int skinPrice)
    {
        if (gameManager.coin >= skinPrice)
        {
            gameManager.coin -= skinPrice;
            //Actualiza el skin actual del jugador al skin comprado
            gameManager.currentSkin = skinIndex;

            PlayerPrefs.SetInt("skin" + skinIndex + "Purchased", 1);

            // Actualiza el valor de PlayerPrefs
            PlayerPrefs.SetInt("CoinsAmount", gameManager.coin);
            Debug.Log("purchase");

            UpdateSkinButtons();
        }
    }

    public void UpdateCoinsText()
    {
        coins.text = "Coins: " + GameManager.instance.coin.ToString();
    }

    public void SelectSkin(int skinIndex)
    {
        selectedSkinIndex = skinIndex;
        SaveSelectedSkinIndex();
        UpdateSkinButtons();
    }

    void LoadSelectedSkinIndex()
    {
        selectedSkinIndex = PlayerPrefs.GetInt("selectedSkinIndex", 1);
    }

    void SaveSelectedSkinIndex()
    {
        PlayerPrefs.SetInt("selectedSkinIndex", selectedSkinIndex);
    }

    void UpdateSkinButtons()
    {
        for (int i = 0; i < skinCount; i++)
        {
            if (PlayerPrefs.GetInt("skin" + i + "Purchased", 0) == 1)
            {
                if (i == selectedSkinIndex - 1)
                {
                    skinButtonTexts[i].text = "Seleccionado";
                    skinButtons[i].interactable = false;
                }
                else
                {
                    skinButtonTexts[i].text = "Seleccionar";
                    skinButtons[i].interactable = true;
                }
            }
            else
            {
                int cost = skinButtons[i].GetComponent<Buttons>().costoSkin;

                if (cost <= 0)
                {
                    skinButtonTexts[i].text = "Seleccionado";
                    skinButtons[i].interactable = false;
                }
                else
                {
                    skinButtonTexts[i].text = cost + "$";
                    skinButtons[i].interactable = true;
                }
            }
        }
    }
}
