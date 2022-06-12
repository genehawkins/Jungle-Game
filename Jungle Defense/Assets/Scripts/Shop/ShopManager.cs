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
    public Button[] BuyBtn;

    void Start()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanelsGO[i].SetActive(true);
        }

        coinsUI.text = "Coins: " + coins.ToString();
        LoadShop();
        CheckBuy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins += 50;
        coinsUI.text = "Coins: " + coins.ToString();
        CheckBuy();
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

    public void CheckBuy()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            if (coins >= ShopItemsSO[i].basecost)
            {
                BuyBtn[i].interactable = true;
            }
            else
            {
                BuyBtn[i].interactable = false;
            }
        }
    }

    public void BuyItem(int btnNo)
    {
        if (coins >= ShopItemsSO[btnNo].basecost)
        {
            coins -= ShopItemsSO[btnNo].basecost;
            coinsUI.text = "Coins: " + coins.ToString();
            CheckBuy();
            //unlock item
        }
    }
}

