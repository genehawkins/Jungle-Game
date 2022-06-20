using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshStart : Card
{
    [SerializeField] private float healthLoss = 2f;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;
        var homeBase = GameManager.instance.baseHealth;

        if (homeBase.GetBaseHealth() > 2 && CanPlay()) {
            PlayCard();

            homeBase.DamageBase(healthLoss);

            cardManager.Mulligan();
        }
    }
}
