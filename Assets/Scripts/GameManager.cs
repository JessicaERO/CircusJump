using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin = 0;
    public Text coinText;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "COINS: " + coin.ToString();
    }
}
