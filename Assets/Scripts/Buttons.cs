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
        button.onClick.AddListener(ComprarSkin);
    }

    private void ComprarSkin()
    {
        if (gameManager.coin >= costoSkin)
        {
            gameManager.coin -= costoSkin;
            shop.UpdateCoinsText(); // Actualizar monedas en la tienda
            shop.PurchaseSkin(skinIndex, costoSkin);
        }
    }
}
