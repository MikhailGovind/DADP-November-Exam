using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //object variables
    private GameObject[] BlockObstacles;
    private GameObject[] PushObstacles;
    private GameObject[] BackPushObstacles;
    private GameObject[] ExplodeObstacles;
    private GameObject[] TeleportObstacles;


    private void Start()
    {
        //obstacles have to have these  tags
        BlockObstacles = GameObject.FindGameObjectsWithTag("BlockObstacles");
        PushObstacles = GameObject.FindGameObjectsWithTag("PushObstacles");
    }


    //public bool PushObstacle(Vector2 position)
    //{


    //}

    




}
