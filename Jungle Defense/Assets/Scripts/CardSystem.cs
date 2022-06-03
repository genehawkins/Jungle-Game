using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardSystem : MonoBehaviour
{
    [Header("Unity Setup")]
    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;

    //Pulls a random card from a list of cards and displays the drawn card in an available hand slot
    public void DrawCard()
    {
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
        //Updates text that shows number of cards in deck and in discard pile
        deckSizeText.text = $"Cards in deck:\n{deck.Count.ToString()}";
        discardPileSizeText.text = $"Cards in discard:\n{discardPile.Count.ToString()}";
    }
}
