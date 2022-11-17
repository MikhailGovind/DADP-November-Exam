using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    [field: SerializeField]
    public EnemyController enemyController { get; private set; }

    [field: SerializeField]
    public PlayerController playerController { get; private set; }

    [field: SerializeField]
    public Timer timer { get; private set; }

    [field: SerializeField]
    public PlayerPoints playerPoints { get; private set; }


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
        yield return null;
    }

    public IEnumerator TimerTurn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
        yield return null;

    }

    public void noMovesLeft()
    {
        if (playerController.movesCounter == 0)
        {
            playerLose();
        }
    }

    public void noTimeLeft()
    {
        if (timer.TimeLeft == 0f)
        {
            playerWin();
        }
    }

    private void Update()
    {
        if (playerController.PlayerPosition == enemyController.EnemyPosition)
        {
            playerLose();
        }
    }

    public void playerWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void playerLose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
