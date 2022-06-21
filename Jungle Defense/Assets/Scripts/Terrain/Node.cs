using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public TerrainType terrainType;
    private GameObject build;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (!GameManager.instance.cardSystem.currentlySelected) return;
    
        spr.color = CheckNode() ? Color.gray : Color.red;
    }

    private void OnMouseExit()
    {
        spr.color = Color.white;  //Returns node to initial color when mouse moves away
    }

    private void OnMouseDown()
    {
        // Check if user is clicking on UI and not the Node
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        // Check if something is already built here
        if (build != null) return;
        
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();  //Retrieve selected prefab from build manager
        if (thingToBuild == null) return;

        //Places currently selected prefab on node
        if (thingToBuild != null && cardManager.currentlySelected.CanPlay() && CheckNode())
        {
            build = Instantiate(thingToBuild, transform.position, Quaternion.identity);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        } else {
            GameManager.instance.PlayErrorSound();
            
            //TODO - Animate card to wiggle...meh
            cardManager.currentlySelected.CardShake();
        }
    }

    //Checks if node matches placement rules of build
    private bool CheckNode()
    {
        var curSel = GameManager.instance.cardSystem.currentlySelected;
        if (!curSel || !curSel.TryGetComponent<PlaceableCard>(out var sel)) return false;
        return terrainType == sel.terrainType;
    }
}
