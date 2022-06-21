using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldOffering : Card
{
    [SerializeField] private int coinLoss = 20;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (CanPlay() && MoneyManager.coins >= coinLoss && cardManager.hand.Count > 1) {
            PlayCard();

            MoneyManager.MakePurchase(coinLoss);

            Card randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
            while (randCard == this) {
                randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
            }

            randCard.isFree = true;
            
        }
    }
}
