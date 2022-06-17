using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
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
        LoadShop();
        UpdateBuyButtons();
    }

    public void LoadShop()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanels[i].titleTxt.text = ShopItemsSO[i].title;
            ShopPanels[i].description.text = ShopItemsSO[i].desc;
            ShopPanels[i].costTxt.text = ShopItemsSO[i].cost.ToString();
        }
    }

    private void UpdateBuyButtons()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            BuyBtn[i].interactable = MoneyManager.CanPurchase(ShopItemsSO[i].cost);
        }
    }

    public void BuyItem(int btnNo)
    {
        var cost = ShopItemsSO[btnNo].cost;
        
        // Check if player can afford the item.
        if (!MoneyManager.CanPurchase(cost)) return;
        
        // Make the purchase
        MoneyManager.MakePurchase(cost); // Removes coins from MoneyManager.
        UpdateBuyButtons();
        
        // TODO: Add Purchased Card to Deck
        // TODO: GameManager.instance.cardSystem.deck.Add();
    }
}

