using UnityEngine;
using UnityEngine.UI;


public class SkinShop : MonoBehaviour 
{

    public ShopButton[] shopButtons;
    public Text coinsText;

    private void Start() 
    {
        //PlayerPrefs.SetInt("CoinsAmount", 999);
        UpdateCoins();
    }

    public void UpdateCoins() 
    {
        coinsText.text = PlayerPrefs.GetInt("CoinsAmount").ToString();
    }
}