using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrassTile : MonoBehaviour
{
    private SpriteRenderer spr;
    private GameObject towerSet;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Placement.currentMode != PlacementMode.Tower || towerSet != null) return;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            spr.color = Color.white;
            return;
        }
        
        // Change Color on MouseOver
        spr.color = Color.gray;
        
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    private void OnMouseExit()
    {
        // Reset Color back when Mouse leaves
        spr.color = Color.white;
    }

    private void PlaceTower()
    {
        Debug.Log("Placing Tower");
        
        towerSet = Instantiate(Placement.currentlySelected, transform.position, Quaternion.identity);
        towerSet.transform.SetParent(transform);
        
        Placement.ResetPlacement();
    }
}
