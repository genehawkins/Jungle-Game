using TMPro;
using UnityEngine;

public class waveText : MonoBehaviour
{
    private TextMeshProUGUI tmpro;

    private void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var wave = WaveSpawner.instance.waveNum;
        tmpro.text = $"Wave: {wave.ToString("00")}";
    }
}
