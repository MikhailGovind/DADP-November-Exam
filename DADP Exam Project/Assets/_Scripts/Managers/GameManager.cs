/*Script created by R-D
 * Created: 05/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


// GameManager that controls flow of game and other manager classes 
public class GameManager : MonoBehaviour
{

    [SerializeField]
    public Camera myCamera;

    //Singleton of GameManager - can access anywhere in project
    public static GameManager Instance;
    protected GameState State { get; private set; } // current game state - see below enum for various phases
    
    [field: SerializeField] public GridManager gridManager { get; private set; }
  
    
    private void Awake()
    {
        Instance = this; // setup of Singleton
    }

    private void Start()
    {
        UpdateGameState(GameState.LevelSetup);
    }


    // Function: Changes the current state of the game
    // and sets in motion the relevant changes
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState)
        {
            case(GameState.LevelSetup):
                gridManager.GenerateGrid();
                gridManager.ObstaclePlacement();
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

// The various states/phases of the game
public enum GameState
{
    LevelSetup,
    PlayerTurn,
    EnemyTurn,
    Victory,
    Defeat
}