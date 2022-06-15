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

    [NonSerialized] public bool hovering = false;
    public GameObject cardHighlight;
    
    private void Update()
    {
        HighlightCard();
    }

    private void HighlightCard()
    {
        cardHighlight.SetActive(activateCost <= GameManager.instance.cardSystem.actionPoints);
    }

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

    // Executes Card Function when Clicked On
    private void OnMouseDown()
    {
        // Check if UI is over card.
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if (!hasBeenPlayed && GameManager.inSetupPhase)
        {
            CardFunction();
        }
    }

    public virtual void CardFunction()
    {
        Debug.Log("No Function");
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
    
    // Moves a card to discard pile
    private IEnumerator MoveToDiscardPile()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.cardSystem.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}
