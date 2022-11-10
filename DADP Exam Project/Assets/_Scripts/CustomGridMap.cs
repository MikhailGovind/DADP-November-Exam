using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomGridMap: TextUtilities
{
    
    private int width;
    private int height;
    private float cellSize;
    private int[,] grid;
    private TextMesh gridOverlay;

    public CustomGridMap(int w, int h, float c)
    {
        
        width = w;
        height = h;
        cellSize = c;

        grid = new int[width, height];

        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridOverlay = CreateBasicOverlay(grid[i, j].ToString(), null, GetGridPosition(i, j), 14, null, TextAnchor.MiddleCenter);
                gridOverlay.name = $"Cell {i}, {j}";
            }
        }
            
       
    }
    private Vector3 GetGridPosition(int i, int j)
    {
        return new Vector3(i, j) * cellSize;
    }



}
