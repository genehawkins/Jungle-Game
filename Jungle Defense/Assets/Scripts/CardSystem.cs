using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections;

public class CardSystem : MonoBehaviour
{
    [Header("Values to balance")]
    public int drawCardCount = 3;
    [NonSerialized] public int actionPoints = 0;
    public int actionPointsPerWave = 4;
    [NonSerialized] public Card currentlySelected;

    [Header("Unity Setup")]
    public AudioManager audioManager;
    public BuildManager buildManager;
    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;
    public TextMeshProUGUI actionPointText;
    public TextMeshProUGUI currentBuildText;
    public TextMeshProUGUI deploymentCostText;

    void Start()
    {
        // Listens for Unity Event that announces setup phase beginning to draw new card
        GameManager.SetupPhase.AddListener(DrawNewHand);
        Invoke(nameof(DrawNewHand), 1f);
    }

    //Pulls a random card from a list of cards and displays the drawn card in an available hand slot
    public void DrawCard()
    {
        if (deck.Count < 1) 
        {
            Shuffle();
        }

        if (deck.Count >= 1) 
        {
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++) 
            {
                if (availableCardSlots[i] == true)
                {
                    randomCard.gameObject.SetActive(true);
                    randomCard.handIndex = i;
                    randomCard.transform.position = cardSlots[i].position;
                    randomCard.hasBeenPlayed = false;
                    deck.Remove(randomCard);
                    availableCardSlots[i] = false;
                    audioManager.Play("DrawCard");
                    return;
                }
            }
        }
    }

    //Draws a new hand of cards and increases action point allowance
    public void DrawNewHand()
    {

        for (int i = 0; i < drawCardCount; i++) {
            DrawCard();
        }
        actionPoints += actionPointsPerWave;
    }

    //Adds items in discard pile back into deck and clears discard pile list
    public void Shuffle()
    {
        if (discardPile.Count >= 1)
        {
            audioManager.Play("CardShuffle");  //Sound of shuffling cards when shuffled back into deck
            foreach (Card card in discardPile)
            {
                deck.Add(card);
            }
            
            discardPile.Clear();
        }
    }

    private void Update()
    {
        //Updates cardUI text
        deckSizeText.text = $"Cards in deck:\n{deck.Count.ToString()}";
        discardPileSizeText.text = $"Cards in discard:\n{discardPile.Count.ToString()}";
        actionPointText.text = $"Action Pts:\n{actionPoints.ToString()}";
        
        if (currentlySelected != null) {
            currentBuildText.text = $"Current build:\n{currentlySelected.name}";
            deploymentCostText.text = $"Deployment cost:\n{currentlySelected.activateCost}";
        } else {
            currentBuildText.text = $"Current build:";
            deploymentCostText.text = $"Deployment cost:";
        }
    }

    public bool CanPlay()
    {
        if (actionPoints >= currentlySelected.activateCost) {
            return true;
        }
        return false;
    }
}
