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
        //UpdateSkinButtons();
        UpdateShop();
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

            //UpdateSkinButtons();
            UpdateShop();
        }
    }

    public void UpdateCoinsText()
    {
        coins.text = "Coins: " + GameManager.instance.coin.ToString();
    }

    //public void SelectSkin(int skinIndex)
    //{
    //    selectedSkinIndex = skinIndex;
    //    SaveSelectedSkinIndex();
    //    //UpdateSkinButtons();
    //    UpdateShop();
    //}

    void LoadSelectedSkinIndex()
    {
        selectedSkinIndex = PlayerPrefs.GetInt("selectedSkinIndex", 1);
    }

    void SaveSelectedSkinIndex()
    {
        PlayerPrefs.SetInt("selectedSkinIndex", selectedSkinIndex);
    }

    public void UpdateShop()
    {
        // Cargar la skin seleccionada actualmente
        selectedSkinIndex = PlayerPrefs.GetInt("selectedSkinIndex", 0);

        // Actualizar los botones de la tienda
        for (int i = 0; i < skinButtons.Length; i++)
        {
            // Obtener el botón y el texto del botón para esta skin
            Button button = skinButtons[i];
            Text buttonText = skinButtonTexts[i];

            // Comprobar si esta skin ya está comprada
            bool isPurchased = PlayerPrefs.GetInt("Skin" + i, 0) == 1;

            if (isPurchased)
            {
                // Si la skin ya está comprada, comprobar si es igual a la skin seleccionada actualmente
                if (i == selectedSkinIndex)
                {
                    // Si la skin ya está seleccionada, mostrar "seleccionado" y bloquear el botón
                    buttonText.text = "Seleccionado";
                    button.interactable = false;
                }
                else
                {
                    // Si la skin no está seleccionada, mostrar "seleccionar" y habilitar el botón
                    buttonText.text = "Seleccionar";
                    button.interactable = true;
                }
            }
            else
            {
                // Si la skin no está comprada, mostrar el precio y habilitar el botón
                buttonText.text = skinButtons[i].GetComponent<Buttons>().costoSkin.ToString();
                button.interactable = true;
            }
        }
    }

    public void SelectSkin(int index)
    {
        // Comprobar si esta skin ya está comprada
        bool isPurchased = PlayerPrefs.GetInt("Skin" + index, 0) == 1;
        Buttons buttons = skinButtons[index].GetComponent<Buttons>();

        if (isPurchased)
        {
            // Si la skin ya está comprada, seleccionarla y guardar la selección
            selectedSkinIndex = index;
            PlayerPrefs.SetInt("selectedSkinIndex", selectedSkinIndex);
        }
        else
        {
            // Si la skin no está comprada, comprobar si el jugador tiene suficiente dinero para comprarla
            if (gameManager.coin >= buttons.costoSkin)
            {
                // Si el jugador tiene suficiente dinero, comprar la skin y guardar la compra
                gameManager.coin -= buttons.costoSkin;
                PlayerPrefs.SetInt("Money", gameManager.coin);
                PlayerPrefs.SetInt("Skin" + index, 1);

                // Seleccionar la skin y guardar la selección
                selectedSkinIndex = index;
                PlayerPrefs.SetInt("selectedSkinIndex", selectedSkinIndex);
            }
        }

        // Actualizar la tienda para reflejar los cambios
        UpdateShop();
    }

    //void UpdateSkinButtons()
    //{
    //    for (int i = 0; i < skinCount; i++)
    //    {
    //        Debug.Log("for skin: " + i);
    //        if (PlayerPrefs.GetInt("skin" + i + "Purchased", 0) == 1)
    //        {
    //            if (i == selectedSkinIndex - 1)
    //            {
    //                skinButtonTexts[i].text = "Seleccionado";
    //                skinButtons[i].interactable = false;
    //            }
    //            else
    //            {
    //                skinButtonTexts[i].text = "Seleccionar";
    //                skinButtons[i].interactable = true;
    //            }
    //        }
    //        else
    //        {
    //            int cost = skinButtons[i].GetComponent<Buttons>().costoSkin;

    //            if (cost <= 0)
    //            {
    //                skinButtonTexts[i].text = "Seleccionado";
    //                skinButtons[i].interactable = false;
    //            }
    //            else
    //            {
    //                skinButtonTexts[i].text = cost + "$";
    //                skinButtons[i].interactable = true;
    //            }
    //        }
    //    }
    //}
}
