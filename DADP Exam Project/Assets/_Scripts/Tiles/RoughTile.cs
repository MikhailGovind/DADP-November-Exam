/*Script created by R-D
 * Created: 07/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;


/* Class used for RoughTile Prefab and its variants 
 * <- Inherits from BasicTile */
public class RoughTile : BasicTile
{
    [field:SerializeField]
    private bool Walkable { get; set; } // Check if the tile is walkable for units

    [field:SerializeField]
    private bool Pit { get; set; } // Check if the tile is a pit

    [field:SerializeField]
    private GameObject ObjectSlot { get; set; } // Slot to place unit/obstacle in - remember to update SpriteRenderer to show occupier

    [SerializeField]
    private GameObject debugTextContainer; // object containing Debug Text for grid overlay

    
    // Function: makes tiles vary in hue to make grid
    // nature of environment more obvious to player
    public void Init(bool isOffset)
    {
        if(!Pit)
        { 
            spriteRenderer.color = isOffset ? offsetColor : baseColor; 
        }
        
    }
    // Function: returns Debug Text for grid overlay
    // for this specific tile, in form of string
    public string getDebugText()
    {
        return debugTextContainer.GetComponent<TextMeshProUGUI>().text;
    }

    /* Function: change the Debug Text for grid overlay
     * by inputting string to change text to and bool to 
     * indicate if the changed text should be shown on grid */
    public void setDebugText(string change, bool show)
    {
        debugTextContainer.SetActive(true);
        debugTextContainer.GetComponent<TextMeshPro>().text = change;
        if (!show) { debugTextContainer.SetActive(false); }
    }

    // Fucntion: sets Debug Text container object to active if disabled [default]
    // and vice versa
    public void DebugText()
    {
        if (debugTextContainer.activeSelf)
        {
            debugTextContainer.SetActive(false);
        }
        else
        {
            debugTextContainer.SetActive(true);
        }
    }


    // Function: highlights tile on mouse over
    // {see BasicTile: highlight object}
    private void OnMouseEnter()
    {
        if(Walkable)
        {
            highlight.SetActive(true);
        }
    }

    // Function: returns tile to normal on mouse exiting tile
    private void OnMouseExit()
    {
        if(Walkable)
        {
            highlight.SetActive(false);
        }
    }

    
}
