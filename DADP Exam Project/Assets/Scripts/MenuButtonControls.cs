using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControls : MonoBehaviour
{
  public void WinScene()
  {
    SceneManager.LoadScene("WinScene");
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MenuScene");
  }

  public void SampleScene()
  {
    SceneManager.LoadScene("SampleScene");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
