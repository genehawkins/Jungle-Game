using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var value = MoneyManager.coins.ToString("00");
        tmp.text = value;
    }
}
