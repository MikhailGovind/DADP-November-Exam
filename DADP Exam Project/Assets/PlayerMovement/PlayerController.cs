/*Script created by Mikhail
 * Created: 11/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //private variables
    private PlayerControls controls; //to find the PlayerControls script

    //public variables
    public Tilemap collisionTilemap; //variable for collision tilemap which serves are the collision layer
    public int playerMoves; //variable for number of moves player has available

    private void Awake()
    {
        controls = new PlayerControls(); //initialising Player Controls
        playerMoves = 3; //assigning number of moves
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

    // Start is called before the first frame update
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>()); //finding values for whenever the player avatar moves. Reading Vector2 values when performed
    }

    private void Move(Vector2 direction)
    {
        if (playerMoves >= 1) //only allow player to move if they have a move available
        {
            if (CanMove(direction)) //check if the player avatar is colliding with the collision layer or not
                transform.position += (Vector3)direction;
        }
    }

    //check if the player avatar is colliding with the collision layer
    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = collisionTilemap.WorldToCell(transform.position + (Vector3)direction); //finding the grid position
        if (collisionTilemap.HasTile(gridPosition)) //check if tilemap has a tile at this location of the grid
            return false; //if there is a tile, do not allow movement
        return GridManager.gridTiles[transform.position + (Vector3)direction].Walkable; ; //if not, allow movement
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) //check if any movement keys are pressed
        {
            playerMoves -= 1; //on each press subtract from moves available

            if (playerMoves <= 0) //check if moves if less than 0
            {
                playerMoves = 0; //if less than 0, equate it to 0 
            }
        }

        if (playerMoves == 0) //when player moves are less than 0, activate enemy turn
        {
            //enemy turn
        }
    }


    //private bool CanMove(Vector2 direction)
    //{ 
    //    Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
    //    if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
    //        return false;
    //    return true;
    //}

    //private bool CanMove(Vector2 direction)
    //{
    //    if (tag == "Tile")
    //        return false;
    //    return true;
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Tile")
    //    {
    //        player.transform.SetParent(parent.transform, false);
    //    }
    //}
}
