using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject ShopMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Shop();
            }
        }
    }

    public void Resume()
    {
        ShopMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Shop()
    {
        ShopMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}

