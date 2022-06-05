using TMPro;
using UnityEngine;

public class NumEnemiesText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var value = GameManager.instance.enemyTracker.GetNumEnemies().ToString("000");
        tmp.text = $"# Enemies: {value}";
    }
}
