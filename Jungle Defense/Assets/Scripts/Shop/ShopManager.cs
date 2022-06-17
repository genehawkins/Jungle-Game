using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Items")]
    public ShopItemSO[] ShopItemsSO;
    private bool[] shopItemsActive;
    
    [Header("Unity Setup")]
    public ShopTemplate[] ShopPanels;
    public Button[] BuyBtn;
    
    private System.Random rng = new System.Random();

    private void Start()
    {
        shopItemsActive = new bool[ShopItemsSO.Length];
        
        foreach (var panel in ShopPanels)
        {
            LoadPanel(panel);
        }
        
        UpdateBuyButtons();
    }

    private void LoadPanel(ShopTemplate panel)
    {
        int num;
        
        while (true)
        {
            num = rng.Next(0, ShopItemsSO.Length);
            if (!shopItemsActive[num]) break;
        }

        panel.titleTxt.text = ShopItemsSO[num].title;
        panel.apCost.text = ShopItemsSO[num].apCost.ToString();
        panel.description.text = ShopItemsSO[num].desc;
        panel.costTxt.text = ShopItemsSO[num].cost.ToString();
        shopItemsActive[num] = true;
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

