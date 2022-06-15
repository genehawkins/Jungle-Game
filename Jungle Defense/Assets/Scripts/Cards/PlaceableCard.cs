using UnityEngine;
public class PlaceableCard : Card
{
    public GameObject prefab;
    public TerrainType terrainType;
    
    public override void CardFunction()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
            
        //Action point card is played immediately on click
        if (gameObject.CompareTag("ActionPoint")) {
            cardManager.actionPoints++;
            PlayCard();
        }

        //Slides down currently selected card if one exists
        if (cardManager.currentlySelected && this != cardManager.currentlySelected) {
            cardManager.currentlySelected.hovering = false;
            cardManager.currentlySelected.transform.position += Vector3.down * 1f;
        }

        cardManager.currentlySelected = this;
        Debug.Log("currently selected = " + this.name);
            
        GameManager.instance.buildManager.thingToBuild = prefab;  //Sets the current build item to the card's held prefab
    }
}
