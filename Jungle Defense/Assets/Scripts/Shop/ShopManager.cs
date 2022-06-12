using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsUI;
    public ShopItemSO[] ShopItemsSO;
    public ShopTemplate[] ShopPanels;
    public GameObject ShopMenu;
    public GameObject[] ShopPanelsGO;

    void Start()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanelsGO[i].SetActive(true);
        }

        coinsUI.text = "Coins: " + coins.ToString();
        LoadShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins += 50;
        coinsUI.text = "Coins: " + coins.ToString();
    }

    public void Resume()
    {
        ShopMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadShop()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanels[i].titleTxt.text = ShopItemsSO[i].title;
            ShopPanels[i].description.text = ShopItemsSO[i].description;
            ShopPanels[i].costTxt.text = ShopItemsSO[i].basecost.ToString();
        }
    }
}

