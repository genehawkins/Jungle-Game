using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Items")]
    public ShopItemSO[] shopItemsSO;
    private bool[] shopItemsActive;
    
    [Header("Unity Setup")]
    public ShopTemplate[] shopPanels;
    [SerializeField] private int[] currentShop;
    public Button[] buyBtn;
    [SerializeField] private Transform newCardOffscreenPos;
    
    private System.Random rng = new System.Random();

    private void Start()
    {
        shopItemsActive = new bool[shopItemsSO.Length];
        currentShop = new int[shopPanels.Length];

        int i = 0;
        foreach (var panel in shopPanels)
        {
            LoadPanel(i, panel);
            i++;
        }
        
        UpdateBuyButtons();
    }

    private void LoadPanel(int idx, ShopTemplate panel)
    {
        int num;
        
        while (true)
        {
            num = rng.Next(0, shopItemsSO.Length);
            if (!shopItemsActive[num]) break;
        }

        panel.titleTxt.text = shopItemsSO[num].title;
        panel.apCost.text = shopItemsSO[num].apCost.ToString();
        panel.description.text = shopItemsSO[num].desc;
        panel.costTxt.text = shopItemsSO[num].cost.ToString();
        shopItemsActive[num] = true;
        currentShop[idx] = num;
    }

    public void UpdateBuyButtons()
    {
        //Debug.Log("UpdateBuyButtons");
        int btnNo = 0;
        foreach (var btn in buyBtn)
        {
            var cost = shopItemsSO[currentShop[btnNo]].cost;
            //Debug.Log($"Cost: {shopItemsSO[currentShop[btnNo]].cost}, Money: {MoneyManager.coins}");
            btn.interactable = MoneyManager.CanPurchase(cost);
            btnNo++;
        }
    }

    public void BuyItem(int btnNo)
    {
        var cardIdx = currentShop[btnNo];
        var cost = shopItemsSO[cardIdx].cost;
        
        // Check if player can afford the item.
        if (!MoneyManager.CanPurchase(cost)) return;
        
        // Make the purchase
        MoneyManager.MakePurchase(cost); // Removes coins from MoneyManager.
        UpdateBuyButtons();
        
        // TODO: Add Purchased Card to Deck
        var newCardPrefab = shopItemsSO[cardIdx].card;
        var go = Instantiate(newCardPrefab, newCardOffscreenPos.position, Quaternion.identity);
        GameManager.instance.cardSystem.deck.Add(go.GetComponent<Card>());
    }
}

