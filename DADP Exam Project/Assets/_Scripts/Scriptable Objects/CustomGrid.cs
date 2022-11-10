/*Script created by R-D
 * Created: 05/11/2022
 * Modified: */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScriptableObject used to more eaily adjust and interact with grid generated 
[CreateAssetMenu(fileName = "CustomGrid", menuName = "Scriptable Objects/CustomGrid" )]
public class CustomGrid : ScriptableObject
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private float tileSize;

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    private List<Vector2> pits = new List<Vector2>();

    [SerializeField]
    private List<Vector3> obstacles = new List<Vector3>();

    public int Width { get => width; }

    public int Height { get => height; }

    public float TileSize { get => tileSize; }

    public List<Sprite> Sprites { get => sprites; }

    public List<Vector2> Pits { get => pits; }

    public List<Vector3> Obstacles { get => obstacles; }

}
