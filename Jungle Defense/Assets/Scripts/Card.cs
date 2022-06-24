using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    [NonSerialized] public bool hasBeenPlayed;
    [NonSerialized] public int handIndex;
    public int activateCost;
    public TerrainType placementArea;
    public bool hovering = false;

    [Header("Prefab")]
    public GameObject prefab;
    public GameObject cardHighlight;


    void OnMouseOver()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        if (this != cardManager.currentlySelected && !hovering) {
            hovering = true;
            transform.position += Vector3.up * 1f;
        }
    }

    void OnMouseExit()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        if (this != cardManager.currentlySelected && hovering) {
            hovering = false;
            transform.position += Vector3.down * 1f;
        }
    }

    //Selects the card when clicked on
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!hasBeenPlayed && GameManager.inSetupPhase)
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

    void Update()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem

        if (activateCost <= cardManager.actionPoints) {
            cardHighlight.SetActive(true);
        } else {
            cardHighlight.SetActive(false);
        }
    }
}
