using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [field: SerializeField]
    public EnemyController enemyController { get; private set; }

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
        yield return null;
    }

    public IEnumerator TimerTurn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
        yield return null;

    }



}
