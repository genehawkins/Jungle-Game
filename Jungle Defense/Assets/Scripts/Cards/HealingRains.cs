using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRains : Card
{
    [SerializeField] private float healAmount = 3f;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (cardManager.hand.Count >= 3 && CanPlay()) {
            PlayCard();

            for (int i = 0; i < 2; i++) {
                
                var randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
                while (randCard == this) {
                    randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
                }

                cardManager.discardPile.Add(randCard);
                cardManager.hand.Remove(randCard);
                cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
                randCard.gameObject.SetActive(false);
                

            }
        
            GameManager.instance.baseHealth.HealBase(healAmount);

        }
    }
}
