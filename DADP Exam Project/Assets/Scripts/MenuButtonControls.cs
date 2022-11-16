// Button Scripts
// Last updated: 13/11/2022
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControls : MonoBehaviour
{
    [field: SerializeField]
    public PlayerPoints playerPoints { get; private set; }

    public void WinScene()  // General code to load the win or lose scenes
    {
    SceneManager.LoadScene("WinScene");
    }

    public void MainMenu()  // Loads the Menu scene
    {
    SceneManager.LoadScene("MenuScene");
    }

    public void Retry()  // Loads the Game scene
    {
        if (playerPoints.playerPoints == 1)
        {
            SceneManager.LoadScene("Level2");
        }

        if (playerPoints.playerPoints == 2)
        {
            SceneManager.LoadScene("Level3");
        }

        if (playerPoints.playerPoints == 3)
        {
            SceneManager.LoadScene("Level4");
        }

        if (playerPoints.playerPoints == 4)
        {
            SceneManager.LoadScene("Level5");
        }

        if (playerPoints.playerPoints == 5)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void QuitGame()  // Quits and exits the game
    {
    Application.Quit();
    }
}
