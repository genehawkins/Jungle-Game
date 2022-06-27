using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingHand : Card
{
    [SerializeField] private int coinsGained = 5;
    [SerializeField] private float healthGained = 1f;
    
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;
        var homeBase = GameManager.instance.baseHealth;

        if (CanPlay()) {
            GameManager.instance.moneyManager.AddCoins(coinsGained);
            homeBase.HealBase(healthGained);

            cardManager.availableCardSlots[handIndex] = true;
            PlayCard();
            

            cardManager.DrawCard();
        }
    }
}
