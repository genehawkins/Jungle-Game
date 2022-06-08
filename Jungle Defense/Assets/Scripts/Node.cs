using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject build;
    public CardSystem cardManager;

    private Renderer rend;
    private Color startColor;
    public string terrainType;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;  //Saves starting color of node
    }

    void OnMouseEnter()
    {
        if (NodeMatches()) {
            rend.material.color = hoverColor;  //Changes color of node when mouse hovers over
        }
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

        
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();

        //Places currently selected prefab on node
        if (thingToBuild != null && cardManager.CanPlay() && NodeMatches()) {
            build = (GameObject)Instantiate(thingToBuild, transform.position, transform.rotation);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        }
        
    }

    //Checks if node matches placement rules of build
    public bool NodeMatches()
    {
        if (terrainType == cardManager.currentlySelected.placementArea) {
            return true;
        }
        return false;
    }
}
