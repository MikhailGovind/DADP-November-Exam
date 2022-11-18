using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private UnitManager unitManager;

    public Vector2 EnemyPosition { get; private set; }

    public Vector2 PlayerPosition { get; private set; }

    public RoughTile EnemyTile { get; private set; }

    private void Start()
    {
        EnemyPosition = this.transform.position;
        EnemyTile = GridManager.gridTiles[EnemyPosition];
        PlayerPosition = unitManager.playerController.PlayerPosition;
    }

    public int VerticalDistance(Vector2 start, Vector2 finish)
    {
        return (int)Mathf.Abs(finish.y - start.y);
    }

    public int HorizontalDistance(Vector2 start, Vector2 finish)
    {
        return (int)Mathf.Abs(finish.x - start.x);
    }

    public void HPathCalibration(Vector2 Position)
    {
        foreach (KeyValuePair<Vector2, RoughTile> entry in GridManager.gridTiles)
        {
            RoughTile tile = entry.Value;
            tile.PathNode.SetActive(true);
            if(entry.Key == EnemyPosition)
            {
                tile.pathData.setPathVector(new Vector2(0, 0));
            }
            else if(tile.Walkable)
            {
                tile.pathData.setPathVector(new Vector2(HorizontalDistance(entry.Key, Position), VerticalDistance(entry.Key, Position)));
            }
            else if(!tile.Walkable)
            {
                tile.pathData.setPathVector(new Vector2(2000, 2000));
            }
            tile.PathNode.GetComponent<TextMeshPro>().enabled = false;
        }
    }

    


    public RoughTile LeastResistance()
    {
        Vector2 option1 = GridManager.gridTiles[EnemyPosition+new Vector2(0,1)].pathData.pathVector();
        int option1A = (int)(option1.x + option1.y);
        Vector2 option2 = GridManager.gridTiles[EnemyPosition + new Vector2(1, 0)].pathData.pathVector();
        int option2A = (int)(option2.x + option2.y);
        Vector2 option3 = GridManager.gridTiles[EnemyPosition + new Vector2(0, -1)].pathData.pathVector();
        int option3A = (int)(option3.x + option3.y);
        Vector2 option4 = GridManager.gridTiles[EnemyPosition + new Vector2(-1, 0)].pathData.pathVector();
        int option4A = (int)(option4.x + option4.y);

        if(option1A < option2A && option1A < option3A && option1A < option4A)
        {
            return GridManager.gridTiles[EnemyPosition + new Vector2(0, 1)];
        }
        else if(option2A < option3A && option2A < option4A)
        {
            return GridManager.gridTiles[EnemyPosition + new Vector2(1, 0)];
        }
        else if (option3A < option4A)
        {
            return GridManager.gridTiles[EnemyPosition + new Vector2(0, -1)];
        }
        else
        {
            return GridManager.gridTiles[EnemyPosition + new Vector2(-1, 0)];
        }

    }

    public void Move(RoughTile NewTile)
    {
        this.transform.position = NewTile.transform.position;
        EnemyPosition = this.transform.position;
        EnemyTile = GridManager.gridTiles[EnemyPosition];
    }



    public void EnemyMove(Vector2 Target)
    {
        HPathCalibration(Target);
        Move(LeastResistance());
    }
}
