using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Scriptable Objects/Obstacle")]
public class Obstacle : ScriptableObject
{
    [SerializeField]
    ObstacleType obstacleType;
    [SerializeField]
    private int blocks;
    [SerializeField]
    private bool movable;
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    public enum ObstacleType
    {
        type1 = 1, // 1 block
        type2 = 2, // 1 block
        type3 = 3, // 2 block
        type4 = 4, // 2 block
        type5 = 5 // 4 block
    }


    public ObstacleType ObsType { get => obstacleType; }

    public int Blocks { get => blocks; }

    public bool Movable { get => movable; }

    public List<Sprite> Sprites { get => sprites; }

}
