using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int skinIndex;
    public int costoSkin;
    public Shop Shop;

    private Button buttons;

    private void Start()
    {
        buttons = GetComponent<Button>();
        buttons.onClick.AddListener(ComprarSkin);
    }

    private void ComprarSkin()
    {
        Shop.PurchaseSkin(skinIndex, costoSkin);
    }
}
