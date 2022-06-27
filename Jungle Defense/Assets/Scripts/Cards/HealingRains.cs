using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRains : Card
{
    [SerializeField] private float healAmount = 3f;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (CanPlay()) {
            PlayCard();

            for (int i = 0; i < 2; i++) {
                
                var randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
                while (randCard == this) {
                    randCard = cardManager.hand[Random.Range(0, cardManager.hand.Count)];
                }

                cardManager.availableCardSlots[randCard.handIndex] = true;  //Frees up the spot in the hand
                cardManager.discardPile.Add(randCard);
                cardManager.hand.Remove(randCard);
                
                randCard.gameObject.SetActive(false);
                

            }
        
            GameManager.instance.baseHealth.HealBase(healAmount);

        }
    }

    public override bool CanPlay()
    {
        var cardManager = GameManager.instance.cardSystem;

        return activateCost <= cardManager.actionPoints && cardManager.hand.Count >= 3;
    }
}
