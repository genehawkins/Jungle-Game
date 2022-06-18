using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public TerrainType terrainType;
    [SerializeField] private Color hoverColor = new Color(169, 169, 169);

    private GameObject build;
    
    private SpriteRenderer spr;
    
    [SerializeField] private AudioClip errorSound;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
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
        spr.material.color = Color.white;  //Returns node to initial color when mouse moves away
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (build != null) {
            Debug.Log("There's already something here");
            
            return;
        }
        
        var cardManager = GameManager.instance.cardSystem; // Get Current CardSystem
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();  //Retrieve selected prefab from build manager
        if (thingToBuild == null) return;

        //Places currently selected prefab on node
        if (thingToBuild != null && cardManager.CanPlay() && CheckNode())
        {
            build = (GameObject)Instantiate(thingToBuild, transform.position, Quaternion.identity);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        } else {
            GameManager.instance.PlayErrorSound();
            //TODO - Animate card to wiggle...meh
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
