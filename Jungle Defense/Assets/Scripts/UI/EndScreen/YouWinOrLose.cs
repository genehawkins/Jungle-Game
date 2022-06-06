using TMPro;
using UnityEngine;

public class YouWinOrLose : MonoBehaviour
{
    public static bool playerWon = false;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = playerWon ? "You Win!" : "You Lose!";
    }
}
