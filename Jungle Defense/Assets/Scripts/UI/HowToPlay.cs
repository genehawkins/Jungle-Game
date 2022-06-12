using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HowToPlay : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;

    public TextMeshProUGUI bodyText;

    static string page1 = @"Jungle Defense is tower defense with a card gaming twist.
    
Each level you will face waves of enemies that are trying to destroy your base.";

    static string page2 = @"Before each wave you are dealt a hand of cards.
    
Use these cards to deploy turrets and lay traps to defend your base against waves of enemies.
    
Once you are finished or cannot play any more cards, start the wave of enemies and watch your stategy play out!";

    static string page3 = @"You'll draw more cards to deploy more traps before each wave.
    
Discover the best use of the cards available to you!";

    static string page4 = @"- Place spike traps on the jungle path to destroy your enemies as they walk over them.
    
- Place vine walls on the jungle path to slow down your enemy's move speed.

- Place turrets in the forest area to shoot enemies from afar!";

    private List<string> pages = new List<string>() { page1, page2, page3, page4 };
    private int pageIdx = 0;

    void Start()
    {
        bodyText.text = page1;
    }

    public void NextPage()
    {
        pageIdx++;
        bodyText.text = pages[pageIdx];
    }

    public void PrevPage()
    {
        pageIdx--;
        bodyText.text = pages[pageIdx];
    }

    public void BackToTitleScreen()
    {
        SceneManager.LoadScene("_StartScreen");
    }


    //Disables side buttons on first and last pages
    void Update()
    {
        if (pageIdx > 0) {
            leftButton.SetActive(true);
        } else {
            leftButton.SetActive(false);
        }

        if (pageIdx < pages.Count - 1) {
            rightButton.SetActive(true);
        } else {
            rightButton.SetActive(false);
        }
    }

    
}
