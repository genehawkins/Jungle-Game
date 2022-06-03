using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card status")]
    public bool hasBeenPlayed;
    public int handIndex;

    [Header("Card Manager")]
    public GameObject cardManager;

    

    //Activates an effect when the card is clicked
    private void OnMouseDown()
    {
        if (!hasBeenPlayed)
        {
            transform.position += Vector3.up * 2f;//For demonstration, the card slidess up and disappears after a second when played
            hasBeenPlayed = true;
            cardManager.GetComponent<CardSystem>().availableCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 1f);

        }
    }

    void MoveToDiscardPile()
    {
        cardManager.GetComponent<CardSystem>().discardPile.Add(this);
        gameObject.SetActive(false);
    }

}
