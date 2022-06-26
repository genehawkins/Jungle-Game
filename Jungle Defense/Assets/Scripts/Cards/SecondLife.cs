using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondLife : Card
{
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (CanPlay()) {
            cardManager.availableCardSlots[handIndex] = true;  //Immediately frees up the card slot since MoveToDiscard is delayed in PlayCard()
            PlayCard();

            //Chooses a random card from discard pile
            Card randomCard = cardManager.discardPile[Random.Range(0, cardManager.discardPile.Count)];
            while (randomCard == this) {
                randomCard = cardManager.discardPile[Random.Range(0, cardManager.discardPile.Count)];
            }

            //Puts random card in first available hand slot
            for (int i = 0; i < cardManager.availableCardSlots.Length; i++) 
            {
                if (cardManager.availableCardSlots[i] == true)
                {
                    randomCard.gameObject.SetActive(true);
                    randomCard.handIndex = i;
                    randomCard.transform.position = cardManager.cardSlots[i].position;
                    randomCard.hasBeenPlayed = false;
                    randomCard.isFree = true;

                    cardManager.discardPile.Remove(randomCard);
                    cardManager.hand.Add(randomCard);
                    cardManager.availableCardSlots[i] = false;
                    
                    return;
                }
            }
        }
    }

    public override bool CanPlay()
    {
        var cardManager = GameManager.instance.cardSystem;

        return activateCost <= cardManager.actionPoints && cardManager.discardPile.Count > 0;
    }
}
