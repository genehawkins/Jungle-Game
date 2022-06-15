using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointCard : Card
{
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem;
        
        cardManager.actionPoints++;
        PlayCard();
        
    }
}
