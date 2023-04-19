using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin = 0;
    public Sprite[] skins;
    public int currentSkin;
    public int totalCoins = 0;
    public Text coinText;
    private int[] passedLevels = new int[] {0,0,0,0,0,0,0,0,0,0};
    public int PassedLevel_1 { get { return passedLevels[0]; } set { value = passedLevels[0]; } }
    public int PassedLevel_2 { get { return passedLevels[1]; } set { value = passedLevels[1]; } }
    public int PassedLevel_3 { get { return passedLevels[2]; } set { value = passedLevels[2]; } }
    public int PassedLevel_4 { get { return passedLevels[3]; } set { value = passedLevels[3]; } }
    public int PassedLevel_5 { get { return passedLevels[4]; } set { value = passedLevels[4]; } }
    public int PassedLevel_6 { get { return passedLevels[5]; } set { value = passedLevels[5]; } }
    public int PassedLevel_7 { get { return passedLevels[6]; } set { value = passedLevels[6]; } }
    public int PassedLevel_8 { get { return passedLevels[7]; } set { value = passedLevels[7]; } }
    public int PassedLevel_9 { get { return passedLevels[8]; } set { value = passedLevels[8]; } }
    public int PassedLevel_10 { get { return passedLevels[9]; } set { value = passedLevels[9]; } }

    public bool prueba;

    private void Awake()
    {
        instance = this;
        LoadData();
    }

    private void OnDestroy()
    {
        SaveData();
    }
    // Update is called once per frame
    void Update()
    {
        if(prueba == true)
        {
            prueba = false;
            for(int i = 0; i <= passedLevels.Length; i++)
            {
                Debug.Log(passedLevels[i]);
            }
        }
    }

    public void AddCoin()
    {
        //Debug.Log("Coin added");
        coin++;
        coinText.text = "COINS: " + coin.ToString();
    }

    public void SaveCoins() 
    {
        PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount", 0) + coin);
        
    }

    public void SaveLevelPassed(int index)
    {
        passedLevels[index] = 1;
    }

    public void LoadData()
    {
        passedLevels[0] = PlayerPrefs.GetInt("WinLevel1", 0);
        passedLevels[1] = PlayerPrefs.GetInt("WinLevel2", 0);
        passedLevels[2] = PlayerPrefs.GetInt("WinLevel3", 0);
        passedLevels[3] = PlayerPrefs.GetInt("WinLevel4", 0);
        passedLevels[4] = PlayerPrefs.GetInt("WinLevel5", 0);
        passedLevels[5] = PlayerPrefs.GetInt("WinLevel6", 0);
        passedLevels[6] = PlayerPrefs.GetInt("WinLevel7", 0);
        passedLevels[7] = PlayerPrefs.GetInt("WinLevel8", 0);
        passedLevels[8] = PlayerPrefs.GetInt("WinLevel9", 0);
        passedLevels[9] = PlayerPrefs.GetInt("WinLevel10", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("WinLevel1", passedLevels[0]);
        PlayerPrefs.SetInt("WinLevel2", passedLevels[1]);
        PlayerPrefs.SetInt("WinLevel3", passedLevels[2]);
        PlayerPrefs.SetInt("WinLevel4", passedLevels[3]);
        PlayerPrefs.SetInt("WinLevel5", passedLevels[4]);
        PlayerPrefs.SetInt("WinLevel6", passedLevels[5]);
        PlayerPrefs.SetInt("WinLevel7", passedLevels[6]);
        PlayerPrefs.SetInt("WinLevel8", passedLevels[7]);
        PlayerPrefs.SetInt("WinLevel9", passedLevels[8]);
        PlayerPrefs.SetInt("WinLevel10", passedLevels[9]);
    }
    //public void UpdateTotalCoins(int skinPrice)
    //{
    //    totalCoins += skinPrice;
    //}
}
