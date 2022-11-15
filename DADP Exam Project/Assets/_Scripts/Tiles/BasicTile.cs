/*Script created by R-D
 * Created: 05/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base tile class used for all tile Prefabs 
 * -> RoughTile inherits from this class */
public class BasicTile : MonoBehaviour
{
    //miks 
    //public int G;
    //public int H;

    //public int F { get { return G + H; } }

    //public bool isBlocked;

    //public BasicTile previous;

    //public Vector3Int gridLocation;

    [SerializeField]
    protected Color baseColor, offsetColor;
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected GameObject highlight;

    


    

}
