using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var value = GameManager.instance.waveSpawner.GetWaveNumber().ToString("00");
        tmp.text = $"Wave: {value}";
    }
}
