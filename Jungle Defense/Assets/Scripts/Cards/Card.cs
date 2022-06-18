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
    public Vector3 startDimensions;
    [SerializeField] private Vector3 blowUpDimensions;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private SpriteRenderer gfxSpr;
    
    void Start()
    {
        startDimensions = transform.localScale;
    }

    
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
            transform.position += Vector3.up * 4f; 
        } else if (this == cardManager.currentlySelected && !hovering) {
            hovering = true;
            transform.position += Vector3.up * 3f;
        }

        transform.localScale = blowUpDimensions;
        spr.sortingOrder = 7;
        gfxSpr.sortingOrder = 8;
    }

    void OnMouseExit()
    {
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        
        if (this != cardManager.currentlySelected && hovering) {
            hovering = false;
            transform.position += Vector3.down * 4f;
        } else if (this == cardManager.currentlySelected && hovering) {
            hovering = false;
            transform.position += Vector3.down * 3f;
        }

        transform.localScale = startDimensions;
        spr.sortingOrder = 5;
        gfxSpr.sortingOrder = 6;
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
