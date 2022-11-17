using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    private GameObject[] BlockObstacles;
    private GameObject[] PushObstacles;
    private GameObject[] BackPushObstacles;
    private GameObject[] ExplodeObstacles;
    private GameObject[] TeleportObstacles;



    private bool ReadyToMove;
    private void Start()
    {
        BlockObstacles = GameObject.FindGameObjectsWithTag("BlockObstacles");
        PushObstacles = GameObject.FindGameObjectsWithTag("PushObstacles");
        BackPushObstacles = GameObject.FindGameObjectsWithTag("BackPushObstacles");
        ExplodeObstacles = GameObject.FindGameObjectsWithTag("ExplodeObstacles");
        TeleportObstacles = GameObject.FindGameObjectsWithTag("TeleportObstacles");
        //obstacles have to have these  tags
    }

    void Update()
    {
        //Player movement
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveinput.Normalize();

        if (moveinput.sqrMagnitude > 0.5)
        {
            if (ReadyToMove)
            {
                ReadyToMove = false;
                Move(moveinput);
            }
        }
        else
        {
            ReadyToMove = true;
        }
    }

    public bool Move(Vector2 direction)
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
