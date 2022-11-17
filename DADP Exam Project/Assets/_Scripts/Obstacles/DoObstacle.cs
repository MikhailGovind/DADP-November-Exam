using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoObstacle : MonoBehaviour
{
    private GameObject[] BlockObstacles;
    private GameObject[] PushObstacles;
    private GameObject[] BackPushObstacles;
    private GameObject[] ExplodeObstacles;
    private GameObject[] TeleportObstacles;

    // Start is called before the first frame update
    void Start()
    {
        BlockObstacles = GameObject.FindGameObjectsWithTag("BlockObstacles");
        PushObstacles = GameObject.FindGameObjectsWithTag("PushObstacles");
        BackPushObstacles = GameObject.FindGameObjectsWithTag("BackPushObstacles");
        ExplodeObstacles = GameObject.FindGameObjectsWithTag("ExplodeObstacles");
        TeleportObstacles = GameObject.FindGameObjectsWithTag("TeleportObstacles");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool Move(Vector2 direction)
    {
        //To move when player interacts with it.
        if (ObstacleBlocks(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    //Move obstacles but check if it is possible from the Player movement script.
    public bool ObstacleBlocks(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;

        foreach (var obj in BlockObstacles)
        {
            if (obj.transform.position.x == newpos.x && obj.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objToPush in PushObstacles)
        {
            if (objToPush.transform.position.x == newpos.x && objToPush.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objToEx in ExplodeObstacles)
        {
            if (objToEx.transform.position.x == newpos.x && objToEx.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objToBack in BackPushObstacles)
        {
            if (objToBack.transform.position.x == newpos.x && objToBack.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objToTeleport in TeleportObstacles)
        {
            if (objToTeleport.transform.position.x == newpos.x && objToTeleport.transform.position.y == newpos.y)
            {
                return true;
            }
        }
        return false;
    }
}
