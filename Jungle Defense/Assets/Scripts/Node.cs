using UnityEngine;

public class Node : MonoBehaviour
{
    public TerrainType terrainType;
    public Color hoverColor;

    private GameObject build;
    private SpriteRenderer spr;
    private Color startColor;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        startColor = spr.material.color;  //Saves starting color of node
    }

    void OnMouseEnter()
    {
        if (CheckNode()) 
        {
            spr.material.color = hoverColor;  //Changes color of node when mouse hovers over
        }
    }

    void OnMouseExit()
    {
        spr.material.color = startColor;  //Returns node to initial color when mouse moves away
    }

    void OnMouseDown()
    {
        if (build != null) {
            Debug.Log("Can't build here no mo");
            return;
        }

        
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();

        //Places currently selected prefab on node
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        if (thingToBuild != null && cardManager.CanPlay() && CheckNode())
        {
            build = (GameObject)Instantiate(thingToBuild, transform.position, Quaternion.identity);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        }
    }

    //Checks if node matches placement rules of build
    private bool CheckNode()
    {
        var curSel = GameManager.instance.cardSystem.currentlySelected;
        if (!curSel) return false;
        return terrainType == curSel.placementArea;
    }
}
