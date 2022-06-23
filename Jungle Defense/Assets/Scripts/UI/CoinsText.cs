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
        var value = GameManager.instance.moneyManager.coins.ToString("00");
        tmp.text = value;
    }
}
