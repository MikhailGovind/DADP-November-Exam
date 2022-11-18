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

    private Vector2 Direction;

    //animation variables
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public TextMeshProUGUI playerMovesText;
    public TextMeshProUGUI movesCounterText;

    private bool ReadyToMove;

    //object variables
    private GameObject[] BlockObstacles;
    private GameObject[] PushObstacles;
    private GameObject[] BackPushObstacles;
    private GameObject[] ExplodeObstacles;
    private GameObject[] TeleportObstacles;

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

        //obstacles have to have these  tags
        BlockObstacles = GameObject.FindGameObjectsWithTag("BlockObstacles");
        PushObstacles = GameObject.FindGameObjectsWithTag("PushObstacles");
        BackPushObstacles = GameObject.FindGameObjectsWithTag("BackPushObstacles");
        ExplodeObstacles = GameObject.FindGameObjectsWithTag("ExplodeObstacles");
        TeleportObstacles = GameObject.FindGameObjectsWithTag("TeleportObstacles");
    }

    private void Move(Vector2 direction)
    {
        if (playerMoves >= 1) //only allow player to move if they have a move available
        {
            if (CanMove(direction)) //check if the player avatar is colliding with the collision layer or not
            {
                playerMoves--; //decrease moves per turn
                movesCounter--; //decreases moves on move counter
                transform.position += (Vector3)direction;
                PlayerPosition = transform.position;
                PlayerTile = GridManager.gridTiles[PlayerPosition];

                animator.SetBool("isWalking", true); //set walking to true
            }
        }

        if (direction.sqrMagnitude > 0.5)
        {
            if (ReadyToMove)
            {
                ReadyToMove = false;
                objectMove(direction);
            }
        }
        else
        {
            ReadyToMove = true;
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

    ///////////////////////////////////////////////////////// obstacle stuff

    public bool objectMove(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();

        //check if player is blocked.
        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    //interacting with the blocks and getting them to something here.
    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;
        //Stactic block, doesn't move.
        foreach (var obj in BlockObstacles)
        {
            if (obj.transform.position.x == newpos.x && obj.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        //Push block, supposed to move obe block at a time in the direction of the player
        foreach (var objToPush in PushObstacles)
        {
            if (objToPush.transform.position.x == newpos.x && objToPush.transform.position.y == newpos.y)
            {

                DoObstacle objpush = objToPush.GetComponent<DoObstacle>();
                if (objToPush && objpush.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Block destroys the player when they come in contact with it
        foreach (var objEx in ExplodeObstacles)
        {
            if (objEx.transform.position.x == newpos.x && objEx.transform.position.y == newpos.y)
            {

                DoObstacle objexplode = objEx.GetComponent<DoObstacle>();
                if (objEx && objexplode.Move(direction))
                {
                    gameObject.SetActive(false);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //This block pushes the player a space backwards.
        foreach (var objToBackPush in BackPushObstacles)
        {
            if (objToBackPush.transform.position.x == newpos.x && objToBackPush.transform.position.y == newpos.y)
            {

                DoObstacle objbackpush = objToBackPush.GetComponent<DoObstacle>();
                if (objToBackPush && objbackpush.Move(direction))
                {
                    transform.Translate(-1, -1, 0);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //This blocks teleports the player to new position on the grid.
        foreach (var objToTeleport in TeleportObstacles)
        {
            if (objToTeleport.transform.position.x == newpos.x && objToTeleport.transform.position.y == newpos.y)
            {

                DoObstacle objteleport = objToTeleport.GetComponent<DoObstacle>();
                if (objToTeleport && objteleport.Move(direction))
                {
                    transform.Translate(5, 5, 0);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
