using System;
using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    [NonSerialized] public bool hasBeenPlayed;
    [NonSerialized] public int handIndex;
    public int activateCost;
    public TerrainType placementArea;

    [Header("Prefab")]
    public GameObject prefab;

    //Selects the card when clicked on
    private void OnMouseDown()
    {
        if (!hasBeenPlayed && GameManager.inSetupPhase)
        {
            var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
            
            if (cardManager.currentlySelected != null) {    
                cardManager.currentlySelected.transform.position += Vector3.down * 1f;
            }
            
            //Action point card is played immediately on click
            if (gameObject.CompareTag("ActionPoint")) {
                cardManager.actionPoints++;
                PlayCard();
            }

            
            transform.position += Vector3.up * 1f;  //Moves positions of cards to indicate current selection

            cardManager.currentlySelected = this;
            Debug.Log("currently selected = " + this.name);

            //TODO - highlight selected card with border or animation
            
            GameManager.instance.buildManager.thingToBuild = prefab;  //Sets the current build item to the card's held prefab
        }
    }

    //Moves a card to discard pile
    private IEnumerator MoveToDiscardPile()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.cardSystem.discardPile.Add(this);
        gameObject.SetActive(false);
    }

    public void PlayCard()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        
        hasBeenPlayed = true;
        
        cardManager.actionPoints -= activateCost;  //Subtracts activation cost from the total action points
        cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
        cardManager.currentlySelected = null;

        StartCoroutine(MoveToDiscardPile());
    }
}
