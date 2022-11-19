/*Script created by R-D
 * Created: 07/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Manager class that is responsible for the palying grid's 
 * setup and the corresponding GridController script */
public class GridManager : MonoBehaviour
{
    public int grid_width{get; private set;}
    public int grid_height{get; private set;}

    [SerializeField]
    private RoughTile tilePrefab; // Tile prefab used to instantiate grid

    [SerializeField]
    private RoughTile pitPrefab;

    [SerializeField]
    private RoughTile winTilePrefab;

    [SerializeField]
    private GridController gridController; // Script responsible for certain grid behaviours and interactions

    public static Dictionary<Vector2, RoughTile> gridTiles { get; private set; } // The collection of references to all the tiles in the grid

    //Function: Generates physical playing, base grid and the accompanying dictionary of references for the tiles therein
    public void GenerateGrid()
    {
        grid_width = gridController.currentGrid.Width; // ScriptableObject {CustomGrid -> TestGrid} data used to set grid parameters
        grid_height = gridController.currentGrid.Height; // ScriptableObject {CustomGrid -> TestGrid} data used to set grid parameters
        
        bool normalTile;

        GameObject gridObject = GameObject.Find("Grid"); // Object in hierarchy that each instantiated tile will attach to as a child

        gridTiles = new Dictionary<Vector2, RoughTile>(); // Note key for dictionary is of type Vector 2 - position in grid.
        
        for(int x = 0; x<grid_width; x++)
        {
            for(int y = 0; y<grid_height; y++)
            {
                Vector2 coordinates = new Vector2(x, y);
                RoughTile spawnedTile;
                if (gridController.currentGrid.Pits.Contains(coordinates))
                {
                    spawnedTile = Instantiate(pitPrefab, new Vector3(x, y), Quaternion.identity, gridObject.transform);
                    spawnedTile.name = $"Pit: {x}|{y}";
                    normalTile = false;
                }
                else if (gridController.currentGrid.WinTiles.Contains(coordinates))
                {
                    spawnedTile = Instantiate(winTilePrefab, new Vector3(x, y), Quaternion.identity, gridObject.transform);
                    spawnedTile.name = $"WinTile: {x}|{y}";
                    normalTile = false;
                }
                else 
                {
                    spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity, gridObject.transform);
                    spawnedTile.name = $"Tile: {x}|{y}";
                    normalTile = true;
                }
                spawnedTile.SetGridPosition(new Vector2(x, y));
                spawnedTile.setDebugText($"{x}|{y}", false);
                var isOffset = ((x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0)) && normalTile;
                


                if (normalTile && x == 0 && y == 0) // bottom left corner
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[6];
                }
                else if (normalTile && x == 0 && y == grid_height -1) // top left corner
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[0];
                }
                else if (normalTile && x == grid_width -1 && y == 0) // bottom right corner
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[8];
                }
                else if (normalTile && x == grid_width - 1  && y == grid_height - 1 ) // top right corner
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[2];
                }
                else if(normalTile && x == 0) // left side
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[3];
                }
                else if (normalTile && y == 0) // bottom side
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[7];
                }
                else if (normalTile && x == grid_width - 1) // right side
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[5];
                }
                else if (normalTile && y == grid_height - 1) // top side
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[1];
                    
                }


                spawnedTile.Init(isOffset);


                gridTiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        GameManager.Instance.myCamera.transform.position = new Vector3((float)grid_width/2 -0.5f, (float)grid_height/2-0.5f, -10); // center camera on generated grid
    }

    // Function: Returns tile at specific position {key: Vector2} in 
    // grid -> method to interact with dictionary of tiles
    public RoughTile GetTileAtPosition(Vector2 position)
    {
       
        position = new Vector2(position.x%(grid_width), position.y%(grid_height));
        return gridTiles[position];
    }

    public RoughTile GetTileAtPositionSpecial(Vector2 position)
    {
        if(position.x<0)
        {
            position.x = grid_width-1;
        }
        if(position.y<0)
        {
            position.y = grid_height - 1;
        }

        position = new Vector2(position.x % (grid_width), position.y % (grid_height));

        return gridTiles[position];
    }

    public void ObstaclePlacement()
    {
        int counter = 1;
        foreach (Vector3 entry in gridController.currentGrid.Obstacles)
        {
            if (!GetTileAtPosition(new Vector2(entry.x, entry.y)).Pit)
            {
                List<GameObject> obstacles = gridController.obstaclesList.ObstaclePrefabs;
                float c = obstacles.Count;
                GetTileAtPosition(new Vector2(entry.x, entry.y)).SetObstacleInSlot(obstacles[(int)Mathf.Lerp(0f, c, (float)entry.z%(c+1)/(float)c)], counter);
                counter++;
            }
        }   

    }





}
