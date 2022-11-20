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

    public void LoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void MainMenu()  // Loads the Menu scene
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LevelSelect() //Loads the level select scene
    {
        SceneManager.LoadScene("LevelSelectScene");
    }

    #region //level loads

    public void Level_1()  // Loads the Menu scene
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level_2()  // Loads the Menu scene
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level_3()  // Loads the Menu scene
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level_4()  // Loads the Menu scene
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level_5()  // Loads the Menu scene
    {
        SceneManager.LoadScene("Level5");
    }

    #endregion  

    public void QuitGame()  // Quits and exits the game
    {
    Application.Quit();
    }
}
