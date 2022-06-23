using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public KeyCode activateCheats = KeyCode.F5;
    private bool cheatsActive = false;
    
    public KeyCode unlimitedMoneyKey = KeyCode.M;
    private bool unlimitedMoneyActive = false;
    
    public KeyCode unlimitedAPKey = KeyCode.N;
    private bool unlimitedAPActive = false;
    
    private void Update()
    {
        CheckKeys();
        
        if (!cheatsActive) return;
        
        // insert new cheats here
        UnlimitedMoney();
        UnlimitedAP();
        
    }

    private void CheckKeys()
    {
        // Activate Cheats:
        if (Input.GetKeyDown(activateCheats))
        {
            if (!cheatsActive)
            {
                cheatsActive = true;
            }
            else
            {
                cheatsActive = false;
                // Add all cheat toggles here
                unlimitedMoneyActive = false;
                unlimitedAPActive = false;
            }
            Debug.Log($"Cheats Active: {cheatsActive}");
        }
        
        if (!cheatsActive) return;
        
        // Unlimited Money:
        if (Input.GetKeyDown(unlimitedMoneyKey))
        {
            unlimitedMoneyActive = !unlimitedMoneyActive;
            Debug.Log($"Unlimited Money Active: {unlimitedMoneyActive}");
        }
        
        // Unlimited Action Points:
        if (Input.GetKeyDown(unlimitedAPKey))
        {
            unlimitedAPActive = !unlimitedAPActive;
            Debug.Log($"Unlimited AP Active: {unlimitedAPActive}");
        }
    }

    private void UnlimitedMoney()
    {
        if (!unlimitedMoneyActive) return;

        var moneyManager = GameManager.instance.moneyManager;
        if (moneyManager.coins != 999)
        {
            // Set Amount of coins to 999
            moneyManager.Set(999);
            
            // Update Shop Buttons
            var shop = GameManager.instance.shopManager;
            if (shop.isActiveAndEnabled)
            {
                shop.UpdateBuyButtons();
            }
        }
    }

    private void UnlimitedAP()
    {
        if (!unlimitedAPActive) return;

        GameManager.instance.cardSystem.actionPoints = 99;
    }
}
