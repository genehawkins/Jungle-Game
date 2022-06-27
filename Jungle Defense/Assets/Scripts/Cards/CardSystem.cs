using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections;

public class CardSystem : MonoBehaviour
{
    [Header("Values to balance")]
    public int drawCardCount = 4;  //Number of cards drawn at the start of each wave
    [NonSerialized] public int actionPoints = 4;  //Actions points available to player to play cards
    public int actionPointsPerWave = 4;  //Action points gained at the start of each wave
    [NonSerialized] public Card currentlySelected;  //Keeps track of the currently selected card

    [Header("Unity Setup")]
    public GameManager gm;
    public List<Card> database;  //Universal card library, contains one copy of every card
    public List<Card> deck;  //Tracks cards in the deck
    public List<Card> hand;  //Tracks cards in hand
    public TextMeshProUGUI deckSizeText;
    public GameObject deckCardSleeve;

    public Transform[] cardSlots;  //Positions for cards in hand
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;
    public GameObject discardCardSleeve;
    //public TextMeshProUGUI actionPointText; MOVED to ActionPointText.cs

    [SerializeField] private AudioClip drawCardSound;
    [SerializeField] private AudioClip shuffleSound;

    void Start()
    {
        // Listens for Unity Event that announces setup phase beginning to draw new card
        GameManager.instance.SetupPhase.AddListener(StartDrawNewHand);
        GameManager.instance.SetupPhase.AddListener(NewWaveActionPoints);
        GameManager.instance.SetupPhase.AddListener(ResetCards);
        Invoke(nameof(StartDrawNewHand), 1f);
    }

    //Pulls a random card from a list of cards and displays the drawn card in an available hand slot
    public void DrawCard()
    {
        if (deck.Count < 1) 
        {
            Shuffle();
        }

        
        
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
                hand.Add(randomCard);
                availableCardSlots[i] = false;
                if (AudioManager.instance) AudioManager.instance.PlayFX(drawCardSound);
                return;
            }            
        }
        
    }

    public void StartDrawNewHand()
    {
        StartCoroutine(DrawNewHand(drawCardCount));
    }
    
    //Draws a new hand of cards and increases action point allowance
    public IEnumerator DrawNewHand(int numCards = 4)
    {

        for (var i = 0; i < numCards; i++) 
        {
            if (AudioManager.instance) AudioManager.instance.PlayFX(drawCardSound);
            DrawCard();
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    //Adds items in discard pile back into deck and clears discard pile list
    public void Shuffle()
    {
        if (discardPile.Count >= 1)
        {
            if (AudioManager.instance) AudioManager.instance.PlayFX(shuffleSound);
            foreach (Card card in discardPile)
            {
                deck.Add(card);
            }
            
            discardPile.Clear();
        }
    }

    //Allows player to discard and draw a new hand **NOTE**Losing health function moved to FrestStart.cs
    public void Mulligan()
    {

        foreach (Card card in hand) {
            discardPile.Add(card);
            card.gameObject.SetActive(false);
            card.handIndex = -1;
            card.hasBeenPlayed = true;
        }

        if (AudioManager.instance) AudioManager.instance.PlayFX(shuffleSound);

        for (int i = 0; i < availableCardSlots.Length; i++) {
            availableCardSlots[i] = true;
        }

        hand.Clear();

        
        StartCoroutine(DrawNewHand(3));
        
    }

    private void Update()
    {
        //Updates cardUI text
        deckSizeText.text = deck.Count.ToString("00");
        if (deck.Count > 0)
        {
            deckCardSleeve.SetActive(true);
        }
        else
        {
            deckCardSleeve.SetActive(false);
        }
        discardPileSizeText.text = discardPile.Count.ToString("00");
        if (discardPile.Count > 0)
        {
            discardCardSleeve.SetActive(true);
        }
        else
        {
            discardCardSleeve.SetActive(false);
        }
        //actionPointText.text = actionPoints.ToString("00"); MOVED to ActionPointText.cs
    }

    //Returns a random card from the database
    public Card GetRandomCard()
    {
        return database[Random.Range(0, database.Count)];
    }

    public void NewWaveActionPoints()
    {
        actionPoints += actionPointsPerWave;
    }


    //Resets hand of cards at start of wave
    private void ResetCards()
    {
        foreach (Card card in hand) {
            card.hovering = false;
            card.transform.position = cardSlots[card.handIndex].position;
            currentlySelected = null;
        }
    }
}
