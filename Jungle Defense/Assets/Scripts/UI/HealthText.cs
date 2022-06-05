using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var value = GameManager.instance.baseHealth.GetBaseHealth().ToString("00");
        tmp.text = $"Health: {value}";
    }
}
