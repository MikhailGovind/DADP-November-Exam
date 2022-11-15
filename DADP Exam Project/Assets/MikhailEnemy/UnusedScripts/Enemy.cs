using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //tried using this script, not being used at the moment
    private PathFinder pathFinder;

    public GameObject enemy;

    private void Start()
    {
        pathFinder = new PathFinder();
    }
}
