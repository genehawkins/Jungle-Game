using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject build;
    public CardSystem cardManager;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;  //Saves starting color of node
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;  //Changes color of node when mouse hovers over
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;  //Returns node to initial color when mouse moves away
    }

    void OnMouseDown()
    {
        if (build != null) {
            Debug.Log("Can't build here no mo");
            return;
        }

        //Places currently selected prefab on node
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();

        
        if (thingToBuild != null) {
            build = (GameObject)Instantiate(thingToBuild, transform.position, transform.rotation);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        }
        
    }

    //TODO - Checks if node matches placement rules of prefab
    
    /*public bool NodeMatches()
    {
        if (gameObject.CompareTag("Path") && cardManager.currentlySelected.placementArea == "Path") {
            return true;
        } else if (gameObject.CompareTag("Grass") && cardManager.currentlySelected.placementArea == "Grass") {
            return true;
        }
        return false;
    }*/
}
