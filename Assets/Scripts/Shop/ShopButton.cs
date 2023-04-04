using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

    public int index;
    public int cost;
    public bool isBought;
    public Button button;
    public Text buttonText;
    public SkinShop skinShop;

    private void Start() 
    {
        if (button == null)
            button.GetComponent<Button>();
        if (buttonText == null)
            buttonText.GetComponentInChildren<Text>();
        if (skinShop == null)
            skinShop = FindObjectOfType<SkinShop>();
        
        isBought = PlayerPrefs.GetInt("Skin" + index, 0) == 1 || index == 0;
        if (!isBought)
            buttonText.text = cost + "$";
        else 
        {
            if (PlayerPrefs.GetInt("selectedSkinIndex") == index) 
            {
                buttonText.text = "Seleccionado";
                button.interactable = false;
            }
            else 
            {
                buttonText.text = "Seleccionar";
                button.interactable = true;
            }
        }

        if (PlayerPrefs.GetInt("selectedSkinIndex", 0) == index) 
        {
            Select();
        }
    }

    public void OnClick() 
    {
        if (!isBought && PlayerPrefs.GetInt("CoinsAmount") >= cost) 
        {
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") - cost);
            isBought = true;
            skinShop.UpdateCoins();
            Select();
        }

        if (isBought && PlayerPrefs.GetInt("selectedSkinIndex") != index) 
        {
            Select();
        }
    }

    private void Select() 
    {
        PlayerPrefs.SetInt("selectedSkinIndex", index);
        buttonText.text = "Seleccionado";
        button.interactable = false;

        foreach (ShopButton shopButton in skinShop.shopButtons) 
        {
            if (shopButton.index != PlayerPrefs.GetInt("selectedSkinIndex", 0) && shopButton.isBought) 
            {
                shopButton.buttonText.text = "Seleccionar";
                shopButton.button.interactable = true;
            }
        }
    }
}
