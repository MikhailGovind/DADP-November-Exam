using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder
{
    //tried using this script, not being used at the moment

    //    [field: SerializeField] public GridManager gridManager { get; private set; }

    //    public List<RoughTile> FindPath(RoughTile start, RoughTile end)
    //    {
    //        List<RoughTile> openList = new List<RoughTile>();
    //        List<RoughTile> closedList = new List<RoughTile>();

    //        openList.Add(start);

    //        while (openList.Count > 0)
    //        {
    //            RoughTile currentRoughTile = openList.OrderBy(x => x.F).First();

    //            openList.Remove(currentRoughTile);
    //            closedList.Add(currentRoughTile);

    //            if (currentRoughTile == end)
    //            {
    //                //finalize our path
    //                return GetFinishedList(start, end);
    //            }

    //            var neigbourTiles = GetNeighbourTiles(currentRoughTile);

    //            foreach (var neighbour in neigbourTiles)
    //            {
    //                if(neighbour.isBlocked || closedList.Contains(neighbour) || Mathf.Abs(currentRoughTile.gridLocation.z - neighbour.gridLocation.z) > 1)
    //                {
    //                    continue;
    //                }

    //                neighbour.G = GetManhattanDistance(start, neighbour);
    //                neighbour.H = GetManhattanDistance(end, neighbour);

    //                neighbour.previous = currentRoughTile;

    //                if (!openList.Contains(neighbour))
    //                {
    //                    openList.Add(neighbour);
    //                }
    //            }
    //        }

    //        return new List<RoughTile>(); 
    //    }

    //    private List<RoughTile> GetFinishedList(RoughTile start, RoughTile end)
    //    {
    //        List<RoughTile> finishedList = new List<RoughTile>();

    //        RoughTile currentTile = end;

    //        while (currentTile != start)
    //        {
    //            finishedList.Add(currentTile);
    //            currentTile = (RoughTile)currentTile.previous;
    //        }

    //        finishedList.Reverse();

    //        return finishedList; 
    //    }

    //    private int GetManhattanDistance(RoughTile start, RoughTile neighbour)
    //    {
    //        return Mathf.Abs(start.gridLocation.x - neighbour.gridLocation.x) + Mathf.Abs(start.gridLocation.y - neighbour.gridLocation.x);
    //    }

    //    private List<RoughTile> GetNeighbourTiles(RoughTile currentRoughTile)
    //    {
    //        var gridTiles = GridManager.gridTiles;

    //        List<RoughTile> neighbours = new List<RoughTile>();

    //        //top
    //        Vector2Int locationToCheck = new Vector2Int(currentRoughTile.gridLocation.x, currentRoughTile.gridLocation.y + 1);

    //        if (gridTiles.ContainsKey(locationToCheck))
    //        {
    //            neighbours.Add(gridTiles[locationToCheck]);
    //        }

    //        //bottom
    //        locationToCheck = new Vector2Int(currentRoughTile.gridLocation.x, currentRoughTile.gridLocation.y - 1);

    //        if (gridTiles.ContainsKey(locationToCheck))
    //        {
    //            neighbours.Add(gridTiles[locationToCheck]);
    //        }

    //        //right
    //        locationToCheck = new Vector2Int(currentRoughTile.gridLocation.x + 1, currentRoughTile.gridLocation.y);

    //        if (gridTiles.ContainsKey(locationToCheck))
    //        {
    //            neighbours.Add(gridTiles[locationToCheck]);
    //        }

    //        //left
    //        locationToCheck = new Vector2Int(currentRoughTile.gridLocation.x - 1, currentRoughTile.gridLocation.y);

    //        if (gridTiles.ContainsKey(locationToCheck))
    //        {
    //            neighbours.Add(gridTiles[locationToCheck]);
    //        }

    //        return neighbours;
    //    }
}