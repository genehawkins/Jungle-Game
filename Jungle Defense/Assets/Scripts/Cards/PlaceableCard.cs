using UnityEngine;
public class PlaceableCard : Card
{
    public GameObject prefab;
    public TerrainType terrainType;
    
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        var curSel = cardManager.currentlySelected;
        

        //Slides down currently selected card if one exists
        if (curSel && this != curSel) {
            curSel.hovering = false;
            curSel.transform.position = cardManager.cardSlots[curSel.handIndex].position;
            curSel.transform.localScale = curSel.startDimensions;
        }

        cardManager.currentlySelected = this;
        Debug.Log("currently selected = " + this.name);
        
            
        GameManager.instance.buildManager.thingToBuild = prefab;  //Sets the current build item to the card's held prefab
    }
}
