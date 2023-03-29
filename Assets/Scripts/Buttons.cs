using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int skinIndex;
    public int costoSkin;
    public Shop shop;
    public GameManager gameManager;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(ComprarSkin);
    }

    public void ComprarSkin()
    {
        Debug.Log("comprar skin: " + PlayerPrefs.GetInt("CoinsAmount", 0) + " - " + costoSkin);

        if (PlayerPrefs.GetInt("CoinsAmount", 0) >= costoSkin)
        {
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount", 0) - costoSkin);
            shop.UpdateCoinsText(); // Actualizar monedas en la tienda
            shop.PurchaseSkin(skinIndex, costoSkin);
        }
    }
}
