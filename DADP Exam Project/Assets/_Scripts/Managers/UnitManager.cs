using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    [field: SerializeField]
    public EnemyController enemyController { get; private set; }

    [field: SerializeField]
    public EnemyController enemyController2 { get; private set; }

    [field: SerializeField]
    public EnemyController enemyController3 { get; private set; }

    [field: SerializeField]
    public PlayerController playerController { get; private set; }


    public float pacing = 2f;

    public void PlayerTurn()
    {
        Debug.Log("PlayerTurn");
        
        playerController.playerMoves = 3;
        playerController.signal = true;
    }

    public void EnemyTurn()
    {
        Debug.Log("EnemyTurn");
        
        
        StartCoroutine(TimerMove((float)pacing*1));
        StartCoroutine(TimerMove((float)pacing*2));
        StartCoroutine(TimerMove((float)pacing*3));
        StartCoroutine(TimerTurn((float)pacing*4));
    }

    
    public IEnumerator TimerMove(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        enemyController.EnemyMove(playerController.PlayerPosition);
        enemyController2.EnemyMove(playerController.PlayerPosition);
        enemyController3.EnemyMove(playerController.PlayerPosition);

        yield return null;
    }

    public IEnumerator TimerTurn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
        yield return null;

    }

    //function for when the player has no moves left on the move counter
    public void noMovesLeft()
    {
        playerLose();
    }

    //function for when the timer runs out
    public void noTimeLeft()
    {
        playerLose();
    }

    //load win scene
    public void playerWin()
    {
        ProgressTracker progressTracker = GameObject.Find("LevelProgressTracker").GetComponent<ProgressTracker>();
        string currentScene = SceneManager.GetActiveScene().name;

        switch(currentScene)
        {
            case "Level1":
                progressTracker.SetLevel1(true);
                break;
            case "Level2":
                progressTracker.SetLevel2(true);
                break;
            case "Level3":
                progressTracker.SetLevel3(true);
                break;
            case "Level4":
                progressTracker.SetLevel4(true);
                break;
            case "Level5":
                progressTracker.SetLevel5(true);
                break;
        }
        
        SceneManager.LoadScene("WinScene");
    }

    //load lose scene
    public void playerLose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
