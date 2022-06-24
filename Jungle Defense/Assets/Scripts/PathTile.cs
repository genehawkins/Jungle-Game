using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : MonoBehaviour
{
    private SpriteRenderer spr;
    private GameObject trapSet;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    
    private void OnMouseOver()
    {
        if (Placement.currentMode != PlacementMode.Trap || trapSet != null) return;
        
        // Change Color on MouseOver
        spr.color = Color.gray;
        
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTrap();
        }
    }

    private void OnMouseExit()
    {
        // Reset Color back when Mouse leaves
        spr.color = Color.white;
    }

    private void PlaceTrap()
    {
        Debug.Log("Placing Tower");
        
        trapSet = Instantiate(Placement.currentlySelected, transform.position, Quaternion.identity);
        trapSet.transform.SetParent(transform);
        
        Placement.ResetPlacement();
    }
}
