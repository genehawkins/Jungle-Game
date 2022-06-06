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
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (build != null) {
            Debug.Log("Can't build here no mo");
            return;
        }

        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();

        if (thingToBuild != null) {
            build = (GameObject)Instantiate(thingToBuild, transform.position, transform.rotation);
            cardManager.currentlySelected.PlayCard();
            BuildManager.instance.thingToBuild = null;
        }
    }
}
