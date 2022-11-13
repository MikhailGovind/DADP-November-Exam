using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObstacleList", menuName = "Scriptable Objects/ObstacleList")]
public class ObstacleList : ScriptableObject
{
    [SerializeField]
    private List<GameObject> obstaclePrefabs = new List<GameObject>();
    public List<GameObject> ObstaclePrefabs { get => obstaclePrefabs; }

}
