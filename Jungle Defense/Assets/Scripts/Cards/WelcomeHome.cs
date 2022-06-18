using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeHome : Card
{
    public override void CardFunction()
    {
        if (CanPlay()) {
            var homeBase = GameManager.instance.baseHealth;

            homeBase.immuneCount += 3;
            PlayCard();
        }
    }
}
