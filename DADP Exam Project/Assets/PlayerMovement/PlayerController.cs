/*Script created by Mikhail
 * Created: 11/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    //private variables
    private PlayerControls controls; //to find the PlayerControls script

    //public variables
    public Tilemap collisionTilemap; //variable for collision tilemap which serves are the collision layer

    [SerializeField]
    public int playerMoves = 0; //variable for number of moves player has available

    [SerializeField]
    public int movesCounter = 0; //variable for total nunmber of moves player has availabe for this level before losing

    [SerializeField]
    public bool signal;

    //private Vector2 Direction;


    //animation variables
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public TextMeshProUGUI playerMovesText;
    public TextMeshProUGUI movesCounterText;

    private bool ReadyToMove;

   

    [field: SerializeField]
    public UnitManager unitManager { get; private set; }

    [field: SerializeField]
    public Timer timer { get; private set; }

    public Vector2 PlayerPosition { get; private set; }

    public RoughTile PlayerTile { get; private set; }

    private void Awake()
    {
        controls = new PlayerControls(); //initialising Player Controls
    }

    //enabling Player Controls
    private void OnEnable()
    {
        controls.Enable();
    }

    //for disabling Player Controls when script is disabled
    private void OnDisable()
    {
        controls.Disable();
    }

    /////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = this.transform.position;
        PlayerTile = GridManager.gridTiles[PlayerPosition];
        //signal = false;

        

        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>()); //finding values for whenever the player avatar moves. Reading Vector2 values when performed

        
        
    }

    private void Move(Vector2 direction)
    {
        if (playerMoves >= 1) //only allow player to move if they have a move available
        {
            if (CanMove(direction) && MoveObstacle((Vector2)transform.position + direction, direction) == 1) //check if the player avatar is colliding with the collision layer or not
            {
                playerMoves--; //decrease moves per turn
                movesCounter--; //decreases moves on move counter
                
                transform.position += (Vector3)direction;
                PlayerPosition = transform.position;
                PlayerTile = GridManager.gridTiles[PlayerPosition];

                animator.SetBool("isWalking", true); //set walking to true
            }
        }

        

        //set direction of sprite to movement direction 
        if (direction.x < 0) //left
        {
            spriteRenderer.flipX = true;

        }
        else if (direction.x > 0) //right
        {
            spriteRenderer.flipX = false;
        }
    }

    //check if the player avatar is colliding with the collision layer
    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = collisionTilemap.WorldToCell(transform.position + (Vector3)direction); //finding the grid position
        if (collisionTilemap.HasTile(gridPosition)) //check if tilemap has a tile at this location of the grid
            return false; //if there is a tile, do not allow movement

        return GridManager.gridTiles[transform.position + (Vector3)direction].Walkable; //if not, allow movement
    }


    public int MoveObstacle(Vector2 position, Vector2 direction)
    {
        if(GridManager.gridTiles[position].CheckSlotEmpty() && !GridManager.gridTiles[position].CheckIfObject())
        {
            return 1;
        }
        else
        {
            ObstacleData ObstacleHolder = GridManager.gridTiles[position].GetObstacle();
            GameObject Obstacle = ObstacleHolder.gameObject;

            Vector2[] EnemyPositions = new Vector2[10];
            for(int k =0; k<EnemyPositions.Length; k++)
            {
                EnemyPositions[k] = Vector2.negativeInfinity;
            }
            
            int counter2 = 0;
            foreach(GameObject entry in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                EnemyPositions[counter2] = (Vector2) entry.transform.position;
                counter2++;
            }

            Vector2 destination = position + direction;
            if (ObstacleHolder.GetObstacleData().Movable && !EnemyPositions.Contains(destination)) 
            {
                GameManager.Instance.gridManager.GetTileAtPositionSpecial(position + direction).ObjectSlot.SetActive(true);
                GameObject Clone = Instantiate(Obstacle, GameManager.Instance.gridManager.GetTileAtPositionSpecial(position + direction).ObjectSlot.transform);
                Clone.name = Obstacle.name;
                Destroy(Obstacle);
                GameManager.Instance.gridManager.GetTileAtPositionSpecial(position).ObjectSlot.SetActive(false);
                return 1;
            }
            else
            {
                return -1;
            }
            
        }
        
    }

    private void Update()
    {
        if (playerMoves <= 0 && signal) //check if moves if less than 0
        {
            playerMoves = 0; //if less than 0, equate it to 0 
            GameManager.Instance.UpdateGameState(GameState.EnemyTurn);
            signal = false;

            animator.SetBool("isWalking", false); //set walking to false to return back to idle
        }

        if (timer.TimeLeft <= 0)
        {
            timer.TimeLeft = 0; //if less than 0, equate it to 0

            unitManager.noTimeLeft(); //call function in unit manager when no moves are left
        }
        
        if (movesCounter <= 0)
        {
            movesCounter = 0; //if less than 0, equate it to 0 

            unitManager.noMovesLeft(); //call function in unit manager when no moves are left
        }

        playerMovesText.text = "" + playerMoves; //sets text to number of player moves available
        movesCounterText.text = "" + movesCounter; //sets text to number left on move counter
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("he's touching me");
            unitManager.playerLose();
        }

        if(other.tag == "WinBlock")
        {
            Debug.Log("Winner");
            unitManager.playerWin();
        }
    }

   
}
