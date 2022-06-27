using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshStart : Card
{
    [SerializeField] private float healthLoss = 2f;
    [SerializeField] private int apGained = 3;

    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;
        var homeBase = GameManager.instance.baseHealth;

        if (CanPlay()) {
            PlayCard();

            homeBase.DamageBase(healthLoss);
            cardManager.actionPoints += apGained;

            cardManager.Mulligan();
        }
    }

    public override bool CanPlay()
    {
        var cardManager = GameManager.instance.cardSystem;
        var homeBase = GameManager.instance.baseHealth;

        return activateCost <= cardManager.actionPoints && homeBase.GetBaseHealth() > 2;
    }
}
