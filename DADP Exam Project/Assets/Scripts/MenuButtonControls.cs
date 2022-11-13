// Button Scripts
// Last updated: 13/11/2022
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControls : MonoBehaviour
{
  public void WinScene()  // General code to load the win or lose scenes
  {
    SceneManager.LoadScene("WinScene");
  }

  public void MainMenu()  // Loads the Menu scene
  {
    SceneManager.LoadScene("MenuScene");
  }

  public void SampleScene()  // Loads the Game scene
  {
    SceneManager.LoadScene("SampleScene");
  }

  public void QuitGame()  // Quits and exits the game
  {
    Application.Quit();
  }
}
