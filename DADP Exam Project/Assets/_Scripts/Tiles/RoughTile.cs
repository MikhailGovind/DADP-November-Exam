/*Script created by R-D
 * Created: 07/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System.Xml.XPath;


/* Class used for RoughTile Prefab and its variants 
 * <- Inherits from BasicTile */
public class RoughTile : BasicTile
{
    [field:SerializeField]
    public bool Walkable { get; private set; } // Check if the tile is walkable for units

    [field:SerializeField]
    public bool Pit { get; private set; } // Check if the tile is a pit

    [field:SerializeField]
    private GameObject ObjectSlot { get; set; } // Slot to place unit/obstacle in - remember to update SpriteRenderer to show occupier

    [SerializeField]
    public GameObject PathNode;

    [SerializeField]
    public PathData pathData; 

    [SerializeField]
    private GameObject debugTextContainer; // object containing Debug Text for grid overlay

    private Vector2 position;
    //internal readonly object F;



    // Function: makes tiles vary in hue to make grid
    // nature of environment more obvious to player
    public void Init(bool isOffset)
    {
        if(!Pit)
        { 
            spriteRenderer.color = isOffset ? offsetColor : baseColor; 
        }
        
    }

    public void SetGridPosition(Vector2 pos)
    {
        position = pos;
    }

    public Vector2 GetGridPostition()
    {
        return position;
    }


    public bool CheckSlotEmpty()
    {
        return (!(ObjectSlot.activeSelf) && ObjectSlot.transform.childCount == 0);
    }

    public void SetObstacleInSlot(GameObject obs, int no)
    {
        if (!CheckSlotEmpty()) { return; }
        Obstacle Obs = obs.GetComponent<ObstacleData>().GetObstacleData();

        ObjectSlot.SetActive(true);
        this.Walkable = false;

        switch (Obs.ObsType)
        {
            case Obstacle.ObstacleType.type1:
            case Obstacle.ObstacleType.type2:
                GameObject temp = GameObject.Instantiate(obs, ObjectSlot.transform);
                temp.name = obs.name + " " + no;
                temp.transform.localPosition = Vector3.zero;
                temp.GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;

            case Obstacle.ObstacleType.type3:
            case Obstacle.ObstacleType.type4:
                RoughTile other_tile = GameManager.Instance.gridManager.GetTileAtPosition(new Vector2(position.x + 1, position.y));
                other_tile.GetComponent<RoughTile>().Walkable = false;

                GameObject other_slot = other_tile.ObjectSlot;
                other_slot.SetActive(true);
                

                GameObject temp1 = GameObject.Instantiate(obs, ObjectSlot.transform);
                temp1.name = obs.name + " " + no;
                temp1.transform.localPosition = Vector3.zero;
                temp1.GetComponent<SpriteRenderer>().sortingOrder = 1;

                temp1 = GameObject.Instantiate(obs, other_slot.transform);
                temp1.name = obs.name + " " + no;
                temp1.transform.localPosition = Vector3.zero;
                temp1.GetComponent<SpriteRenderer>().sprite = obs.GetComponent<ObstacleData>().GetObstacleData().Sprites[1];
                temp1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;

            case Obstacle.ObstacleType.type5:
                RoughTile other_tile1 = GameManager.Instance.gridManager.GetTileAtPosition(new Vector2(position.x + 1, position.y));
                other_tile1.Walkable = false; ;

                GameObject other_slot1 =  other_tile1.ObjectSlot;
                other_slot1.SetActive(true);


                RoughTile other_tile2 = GameManager.Instance.gridManager.GetTileAtPosition(new Vector2(position.x, position.y + 1));
                other_tile2.Walkable = false;
                GameObject other_slot2 =other_tile2.ObjectSlot;
                other_slot2.SetActive(true);


                RoughTile other_tile3 = GameManager.Instance.gridManager.GetTileAtPosition(new Vector2(position.x+1, position.y + 1));
                other_tile3.Walkable = false;
                GameObject other_slot3 = other_tile3.ObjectSlot;
                other_slot3.SetActive(true);

                GameObject temp2 = GameObject.Instantiate(obs, ObjectSlot.transform);
                temp2.name = obs.name + " " + no;
                temp2.transform.localPosition = Vector3.zero;
                temp2.GetComponent<SpriteRenderer>().sortingOrder = 1;

                temp2 = GameObject.Instantiate(obs, other_slot1.transform);
                temp2.name = obs.name + " " + no;
                temp2.transform.localPosition = Vector3.zero;
                temp2.GetComponent<SpriteRenderer>().sprite = obs.GetComponent<ObstacleData>().GetObstacleData().Sprites[1];
                temp2.GetComponent<SpriteRenderer>().sortingOrder = 1;


                temp2 = GameObject.Instantiate(obs, other_slot2.transform);
                temp2.name = obs.name + " " + no;
                temp2.transform.localPosition = Vector3.zero;
                temp2.GetComponent<SpriteRenderer>().sprite = obs.GetComponent<ObstacleData>().GetObstacleData().Sprites[2];
                temp2.GetComponent<SpriteRenderer>().sortingOrder = 1;


                temp2 = GameObject.Instantiate(obs, other_slot3.transform);
                temp2.name = obs.name + " " + no;
                temp2.transform.localPosition = Vector3.zero;
                temp2.GetComponent<SpriteRenderer>().sprite = obs.GetComponent<ObstacleData>().GetObstacleData().Sprites[3];
                temp2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;
        }
        
        
        
        
    }


    // Function: returns Debug Text for grid overlay
    // for this specific tile, in form of string
    public string getDebugText()
    {
        return debugTextContainer.GetComponent<TextMeshPro>().text;
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

    public void PathText()
    {
        if (PathNode.activeSelf)
        {
            PathNode.SetActive(false);
        }
        else
        {
            PathNode.SetActive(true);
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
