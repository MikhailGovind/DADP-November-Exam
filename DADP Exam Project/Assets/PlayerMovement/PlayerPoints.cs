using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int playerPoints;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
