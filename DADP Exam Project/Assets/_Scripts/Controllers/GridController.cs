/*Script created by R-D
 * Created: 05/11/2022
 * Modified: */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

// Class responsible for specific grid behaviours and interactions 
public class GridController: MonoBehaviour
{

    [SerializeField]
    private GridManager gridManager;

   // [field:SerializeField]
    //internal Obstacle1 obs1 { get; private set; }

    [field:SerializeField]
    internal CustomGrid currentGrid { get; private set; } // ScriptableObject of CustomGrid format slots in here

    [field: SerializeField]
    internal ObstacleList obstaclesList { get; private set; }


    // ************************************ //
    // The following section denoted by stars is where the debugging grid overlay is controlled
    // -> switch in Unity Editor bool CustomDebug on Grid GridController script to see Debug Text on each tile
    // -> not meant for player eyes - used for development only
    // ************************************ //
    public delegate void DebuggingEvent();
    // ************************************ //

    //public delegate void DebuggingEvent2();
    // ************************************ //
    // 
    private DebuggingEvent overlaySwitch;

    private DebuggingEvent overlaySwitch2;


    // ************************************ //

    [SerializeField] bool CustomDebug;

    private bool _PrevCustomDebug;

    public bool DebugOverlay
    {
        get { return CustomDebug; }
        set
        {
            CustomDebug = value;

            if (CustomDebug != _PrevCustomDebug)
            {
                overlaySwitch?.Invoke();
            }

            _PrevCustomDebug = CustomDebug;
        }
    }

    // ************************************ //

    [SerializeField] bool CustomDebug2;

    private bool _PrevCustomDebug2;

    public bool DebugOverlay2
    {
        get { return CustomDebug2; }
        set
        {
            CustomDebug2 = value;

            if (CustomDebug2 != _PrevCustomDebug2)
            {
                overlaySwitch2?.Invoke();
            }

            _PrevCustomDebug2 = CustomDebug2;
        }
    }
    // ************************************ //


    // ************************************ //
    private void EnableDebugOverlay()
    {
        foreach (KeyValuePair<Vector2, RoughTile> entry in GridManager.gridTiles)
        {
            entry.Value.DebugText();
        }
        //overlaySwitch -= EnableDebugOverlay;
    }
    // ************************************ //
    private void EnableDebugOverlay2()
    {
        foreach (KeyValuePair<Vector2, RoughTile> entry in GridManager.gridTiles)
        {
            entry.Value.PathText();
        }
        //overlaySwitch2 -= EnableDebugOverlay2;
    }
    // ************************************ //
    private void Start()
    {
        overlaySwitch += EnableDebugOverlay;
        overlaySwitch2 += EnableDebugOverlay2;
    }
    // ************************************ //
    //private void OnValidate()
    //{

    //    if (!Application.isPlaying) { return; }

    //    DebugOverlay = CustomDebug;
    //    DebugOverlay2 = CustomDebug2;
    //}

    private void Update()
    {
        DebugOverlay = CustomDebug;
        DebugOverlay2 = CustomDebug2;
    }

}

