using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.Log("More than one Build Manager in scene!");
            return;
        }
        instance = this;
    }

    //Keeps track of and returns the currently selected prefab to deploy
    public GameObject thingToBuild;  
    
    public GameObject GetThingToBuild()
    {
        return thingToBuild;
    }
}
