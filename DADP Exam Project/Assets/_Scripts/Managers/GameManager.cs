using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public Camera myCamera;


    public static GameManager Instance;
    protected GameState State { get; private set; }
    
    [field: SerializeField] protected GridManager gridManager { get; private set; }
  
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.LevelSetup);
    }



    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState)
        {
            case(GameState.LevelSetup):
                gridManager.GenerateGrid();
                break;
            case (GameState.PlayerTurn):

                break;

            case (GameState.EnemyTurn):

                break;

            case (GameState.Victory):

                break;

            case (GameState.Defeat):

                break;


        }

    }

}

public enum GameState
{
    LevelSetup,
    PlayerTurn,
    EnemyTurn,
    Victory,
    Defeat
}