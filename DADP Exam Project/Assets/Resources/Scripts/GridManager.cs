using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int grid_width, grid_height;

    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    private Camera camera;

    private Dictionary<Vector2, Tile> gridTiles;

    public void GenerateGrid()
    {
        gridTiles = new Dictionary<Vector2, Tile>();
        for(int x = 0; x<grid_width; x++)
        {
            for(int y = 0; y<grid_height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x}, {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                gridTiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        camera.transform.position = new Vector3((float)grid_width/2 -0.5f, (float)grid_height/2-0.5f, -10);
    }


    public Tile GetTileAtPosition(Vector2 position)
    {
        if(gridTiles.TryGetValue(position, out var tile)){
            return tile;
        }
        return null;
    }
}
