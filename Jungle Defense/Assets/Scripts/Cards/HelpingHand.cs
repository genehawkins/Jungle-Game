using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingHand : Card
{
    [SerializeField] private int coinsGained = 5;
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (CanPlay()) {
            GameManager.instance.moneyManager.AddCoins(coinsGained);

            PlayCard();
            cardManager.availableCardSlots[handIndex] = true;

            cardManager.DrawCard();
        }
    }
}
