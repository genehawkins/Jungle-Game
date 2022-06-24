using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI tmpro;

    private void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var hp = GameManager.instance.health;
        tmpro.text = $"Health: {hp.ToString("00")}";
    }
}
