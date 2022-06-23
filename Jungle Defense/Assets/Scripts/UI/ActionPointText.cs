using TMPro;
using UnityEngine;

public class ActionPointText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var value = GameManager.instance.cardSystem.actionPoints.ToString();
        tmp.text = value;
    }
}
