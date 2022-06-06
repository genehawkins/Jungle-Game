using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void MainMenuButton()
    {
        SceneManager.LoadScene("_StartScreen");
    }

    public void LoadNextLevel()
    {
        var idx = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(idx);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
