using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicEnergy : Card
{
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;

        if (AudioManager.instance) AudioManager.instance.PlayFX(cardPlaySound);

        if (CanPlay()) {
            cardManager.actionPointsPerWave++;

            cardManager.actionPoints -= activateCost;  //Subtracts activation cost from the total action points
            isFree = false;

            cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
            cardManager.currentlySelected = null;
            cardManager.hand.Remove(this);

            Destroy(gameObject);
        }
    }
}
