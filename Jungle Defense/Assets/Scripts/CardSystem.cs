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
    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;
    public TextMeshProUGUI actionPointText;
    //public TextMeshProUGUI currentBuildText;
    //public TextMeshProUGUI deploymentCostText;

    void Start()
    {
        // Listens for Unity Event that announces setup phase beginning to draw new card
        GameManager.SetupPhase.AddListener(StartDrawNewHand);
        Invoke(nameof(StartDrawNewHand), 1f);
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
                    if (audioManager) audioManager.Play("DrawCard");
                    return;
                }
            }
        }
    }

    public void StartDrawNewHand()
    {
        StartCoroutine(DrawNewHand());
    }
    
    //Draws a new hand of cards and increases action point allowance
    public IEnumerator DrawNewHand()
    {

        for (var i = 0; i < drawCardCount; i++) 
        {
            DrawCard();
            yield return new WaitForSeconds(0.2f);
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
        deckSizeText.text = deck.Count.ToString("00");
        discardPileSizeText.text = discardPile.Count.ToString("00");
        actionPointText.text = actionPoints.ToString("00");
        
        /*
        if (currentlySelected != null) {
            currentBuildText.text = $"Current build:\n{currentlySelected.name}";
            deploymentCostText.text = $"Deployment cost:\n{currentlySelected.activateCost}";
        } else {
            currentBuildText.text = $"Current build:";
            deploymentCostText.text = $"Deployment cost:";
        }
        */
    }

    public bool CanPlay()
    {
        if (actionPoints >= currentlySelected.activateCost) {
            return true;
        }
        return false;
    }
}
