using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlacementMode
{
    None,
    Tower,
    Trap
}

public class Placement : MonoBehaviour
{
    public static GameObject currentlySelected = null;
    public static PlacementMode currentMode = PlacementMode.None;
    public GameObject prefab;
    public PlacementMode mode;

    public void SelectThis()
    {
        currentlySelected = prefab;
        currentMode = mode;
    }

    public static void ResetPlacement()
    {
        currentlySelected = null;
        currentMode = PlacementMode.None;
    }
}
