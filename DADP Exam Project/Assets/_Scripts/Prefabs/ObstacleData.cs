using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour 
{
    [SerializeField]
    private Obstacle obstacle;
    

    public Obstacle GetObstacleData()
    {
        return obstacle;
    }


}
