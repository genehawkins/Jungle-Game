using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostInFog : Card
{
    public override void CardFunction()
    {
        if (CanPlay()) {
            var homeBase = GameManager.instance.baseHealth;

            homeBase.immuneCount += 3;
            Debug.Log($"Immune count is {homeBase.immuneCount}");
            

            PlayCard();
        }
    }
}
