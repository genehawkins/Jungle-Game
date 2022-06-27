using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    [NonSerialized] public bool hasBeenPlayed;
    [NonSerialized] public int handIndex;
    [NonSerialized] public bool isFree = false;
    
    public int activateCost;
    [NonSerialized] private int normalCost;

    [NonSerialized] public bool hovering = false;
    public GameObject cardHighlight;
    [SerializeField] private Color freeColor;
    private Color startColor;
    public Vector3 startDimensions;
    [SerializeField] private Vector3 blowUpDimensions;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private SpriteRenderer gfxSpr;
    public AudioClip cardPlaySound;
    
    void Start()
    {
        startDimensions = transform.localScale;
        normalCost = activateCost;
        startColor = cardHighlight.GetComponent<SpriteRenderer>().color;
    }

    
    private void Update()
    {
        HighlightCard();
        
        if (isFree) {
            activateCost = 0;
            cardHighlight.GetComponent<SpriteRenderer>().color = freeColor;
        } else {
            activateCost = normalCost;
            cardHighlight.GetComponent<SpriteRenderer>().color = startColor;
        }
    }

    private void HighlightCard()
    {
        cardHighlight.SetActive(CanPlay());
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
        
        if (!hasBeenPlayed && GameManager.instance.inSetupPhase)
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

        if (AudioManager.instance) AudioManager.instance.PlayFX(cardPlaySound);  //Plays audio clip attached to card's prefab
        
        hasBeenPlayed = true;
        
        cardManager.actionPoints -= activateCost;  //Subtracts activation cost from the total action points
        isFree = false;

        cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
        cardManager.currentlySelected = null;
        cardManager.hand.Remove(this);

        StartCoroutine(MoveToDiscardPile());
    }
    
    // Moves a card to discard pile
    private IEnumerator MoveToDiscardPile()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.cardSystem.discardPile.Add(this);
        gameObject.SetActive(false);
    }

    //Checks if player can afford card
    public virtual bool CanPlay()
    {
        return activateCost <= GameManager.instance.cardSystem.actionPoints;
    }

    public void CardShake()
    {
        if (!TryGetComponent(out ShakeMe shaker)) return;
        shaker.Shake();
    }
}
