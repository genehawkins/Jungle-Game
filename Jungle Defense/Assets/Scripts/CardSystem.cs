using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardSystem : MonoBehaviour
{
    public int drawCardCount = 3;
    public int actionPoints = 0;
    public Card currentlySelected;

    [Header("Unity Setup")]
    public BuildManager buildManager;
    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;
    public TextMeshProUGUI actionPointText;

    void Start()
    {
        // Listens for Unity Event that announces setup phase beginning to draw new card
        GameManager.SetupPhase.AddListener(DrawCard);
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
        actionPoints += 3;
    }

    //Adds items in discard pile back into deck and clears discard piile list
    public void Shuffle()
    {
        if (discardPile.Count >= 1)
        {
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
        actionPointText.text = $"Action Pts: {actionPoints.ToString()}";
    }

    
}
