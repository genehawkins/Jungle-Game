using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int coins { get; private set; }

    // Adds Coins to MoneyManager
    public static void AddCoins(int amount)
    {
        coins += amount;
    }

    // Checks if you have enough coins to purchase an object of input: cost
    // Returns true if you do, else false
    public static bool CanPurchase(int cost)
    {
        return coins >= cost;
    }

    // Removes Coins from MoneyManager
    public static void MakePurchase(int cost)
    {
        coins -= cost;
    }
}
