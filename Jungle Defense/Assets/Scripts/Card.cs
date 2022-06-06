using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    public bool hasBeenPlayed;
    public int handIndex;
    public int activateCost;
    

    [Header("Card Manager")]
    public CardSystem cardManager;
    public GameManager gm;
    public BuildManager buildManager;

    [Header("Prefab")]
    public GameObject prefab;


    //Activates an effect when the card is clicked
    private void OnMouseDown()
    {
        if (!hasBeenPlayed && gm.setupPhase && cardManager.actionPoints >= activateCost)
        {
            if (gameObject.tag == "ActionPoint") {
                cardManager.actionPoints++;
                PlayCard();
            }

            cardManager.currentlySelected = this;

            //TODO - highlight selected card with border or animation
            
            buildManager.thingToBuild = prefab;//Sets the current build item to the card's held prefab

        }
    }

    void MoveToDiscardPile()
    {
        cardManager.discardPile.Add(this);
        gameObject.SetActive(false);
    }

    public void PlayCard()
    {
        cardManager.actionPoints -= activateCost;  //Subtracts activation cost from the total action points
        hasBeenPlayed = true;
        cardManager.availableCardSlots[handIndex] = true;  //Frees up the spot in the hand
        cardManager.currentlySelected = null;  
        
        Invoke("MoveToDiscardPile", 1f);
    }

}
