using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    private int grid_width, grid_height;

    [SerializeField]
    private RoughTile tilePrefab;

    [SerializeField]
    private GridController gridController;

    public static Dictionary<Vector2, RoughTile> gridTiles;


    public void GenerateGrid()
    {
        grid_width = gridController.currentGrid.Width;
        grid_height = gridController.currentGrid.Height;

        GameObject gridObject = GameObject.Find("Grid");

        gridTiles = new Dictionary<Vector2, RoughTile>();
        
        for(int x = 0; x<grid_width; x++)
        {
            for(int y = 0; y<grid_height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity, gridObject.transform) ;
                spawnedTile.name = $"Tile: {x}|{y}";
                spawnedTile.setDebugText($"{x}|{y}",false);
                if (x == 0 && y == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[6];
                }
                else if (x == 0 && y == grid_height - 1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[0];
                }
                else if (x == grid_width - 1 && y == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[8];
                }
                else if (x == grid_width - 1 && y == grid_height - 1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[2];
                }
                else if(x == 0) 
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[3];
                }
                else if (y == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[7];
                }
                else if (x == grid_width-1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[5];
                }
                else if (y == grid_height-1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().sprite = gridController.currentGrid.Sprites[1];
                }


                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                gridTiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        GameManager.Instance.myCamera.transform.position = new Vector3((float)grid_width/2 -0.5f, (float)grid_height/2-0.5f, -10);
    }


    public RoughTile GetTileAtPosition(Vector2 position)
    {
        if(gridTiles.TryGetValue(position, out var tile)){
            return tile;
        }
        return null;
    }
}
