using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenTemple : Card
{
    [SerializeField] private int goldAmount = 20;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (cardManager.hand.Count >= 2 && CanPlay()) {
            PlayCard();

            var randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
            while (randCard == this) {
                randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
            }

            cardManager.discardPile.Add(randCard);
            cardManager.hand.Remove(randCard);
            cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
            randCard.gameObject.SetActive(false);

            GameManager.instance.moneyManager.AddCoins(goldAmount);
        }
    }
}
