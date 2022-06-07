using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    public bool hasBeenPlayed;
    public int handIndex;
    public int activateCost;
    public string placementArea;
    

    [Header("Card Manager")]
    public CardSystem cardManager;
    public GameManager gm;
    public BuildManager buildManager;

    [Header("Prefab")]
    public GameObject prefab;

    //Selects the card when clicked on
    private void OnMouseDown()
    {
        if (!hasBeenPlayed && GameManager.inSetupPhase && cardManager.actionPoints >= activateCost)
        {
            if (cardManager.currentlySelected != null) {    
                cardManager.currentlySelected.transform.position += Vector3.down * 1f;
            }
            
            //Action point card is played immediately on click
            if (gameObject.CompareTag("ActionPoint")) {
                cardManager.actionPoints++;
                PlayCard();
            }

            
            transform.position += Vector3.up * 1f;  //Moves positions of cards to indicate current selection

            cardManager.currentlySelected = this;
            Debug.Log("currently selected = " + this.name);

            //TODO - highlight selected card with border or animation
            
            buildManager.thingToBuild = prefab;  //Sets the current build item to the card's held prefab
        }
    }

    //Moves a card to discard pile
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
        
        Invoke(nameof(MoveToDiscardPile), 0.5f);
    }

}
