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
    public Vector2 PrevEnemyPosition { get; private set; }
    public Vector2 PlayerPosition { get; private set; }

    public RoughTile EnemyTile { get; private set; }

    public bool enemyAlive;

    private void Start()
    {
        enemyAlive = true;
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
            tile.PathNode.SetActive(false);
        }
    }

    public RoughTile LeastResistance()
    {
        Vector2 upMove = EnemyPosition + Vector2.up;
        Vector2 leftMove = EnemyPosition + Vector2.left;
        Vector2 downMove = EnemyPosition + Vector2.down;
        Vector2 rightMove = EnemyPosition + Vector2.right;
        GridManager gridM = GameManager.Instance.gridManager;

        Vector2 option1;
        if (upMove.y > gridM.grid_height)
        {
            option1 = new Vector2(10000,10000);
            
        }
        else
        {
            option1 = GridManager.gridTiles[upMove].pathData.pathVector();
        }
        int option1A = (int)(option1.x + option1.y);


        Vector2 option2;
        if (leftMove.x > gridM.grid_width)
        {
            option2 = new Vector2(10000, 10000);
        }
        else
        {
           option2 = GridManager.gridTiles[leftMove].pathData.pathVector();
        }
        int option2A = (int)(option2.x + option2.y);


        Vector2 option3;
        if (downMove.y < 0)
        {
            option3 = new Vector2(10000, 10000);
        }
        else
        {
            option3 = GridManager.gridTiles[downMove].pathData.pathVector();
        }
        int option3A = (int)(option3.x + option3.y);

        Vector2 option4;
        if (rightMove.x < 0)
        {
           option4 = new Vector2(10000, 10000);
        }
        else
        {
           option4 = GridManager.gridTiles[rightMove].pathData.pathVector();
        }
        int option4A = (int)(option4.x + option4.y);


        //if (option1A == option4A && PlayerPosition.y > EnemyPosition.y)
        //{
        //    return GridManager.gridTiles[upMove];
        //}
        //else if (option1A == option4A && PlayerPosition.y < EnemyPosition.y)
        //{
        //    return GridManager.gridTiles[downMove];
        //}

        //else if (option1A == option2A && PlayerPosition.y > EnemyPosition.y)
        //{
        //    return GridManager.gridTiles[upMove];
        //}

        //else if (option2A == option3A && PlayerPosition.x < EnemyPosition.x)
        //{
        //    return GridManager.gridTiles[leftMove];
        //}
        //else if (option2A == option3A && PlayerPosition.x > EnemyPosition.x)
        //{
        //    return GridManager.gridTiles[rightMove];
        //}


        if (option1A < option2A && option1A < option3A && option1A < option4A)
        {
            return GridManager.gridTiles[upMove];
        }
        

        else if(option2A < option3A && option2A < option4A)
        {
            return GridManager.gridTiles[leftMove];
        }
        else if (option3A < option4A)
        {
            return GridManager.gridTiles[downMove];
        }
        else
        {
            return GridManager.gridTiles[rightMove];
        }

    }

    public void Move(RoughTile NewTile)
    {
        PrevEnemyPosition = this.transform.position;
        this.transform.position = NewTile.transform.position;
        EnemyPosition = this.transform.position;
        EnemyTile = GridManager.gridTiles[EnemyPosition];
    }

    public void EnemyMove(Vector2 Target)
    {
        HPathCalibration(Target);
        Move(LeastResistance());
    }



    private void Update()
    {
        if (enemyAlive == false)
        {
            unitManager.playerWin();
        }
    }
}
