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

    // ************************************ //
    // The following section denoted by stars is where the debugging grid overlay is controlled
    // -> switch in Unity Editor bool CustomDebug on Grid GridController script to see Debug Text on each tile
    // -> not meant for player eyes - used for development only
    // ************************************ //
    public delegate void DebuggingEvent();
    private DebuggingEvent overlaySwitch;

    [SerializeField] bool CustomDebug;

    private bool _PrevCustomDebug;

    public bool DebugOverlay
    {
        get { return CustomDebug; }
        set{
            CustomDebug = value;

            if (CustomDebug != _PrevCustomDebug)
            {
                overlaySwitch?.Invoke();
            }

            _PrevCustomDebug = CustomDebug;
        }
    }

    private void OnValidate()
    {
        
        if (!Application.isPlaying) return;

        DebugOverlay = CustomDebug;
    }

    private void EnableDebugOverlay()
    {
        foreach (KeyValuePair<Vector2, RoughTile> entry in GridManager.gridTiles)
        {
            entry.Value.DebugText();
        }
    }
    // ************************************ //


    private void Start()
    {
        overlaySwitch = EnableDebugOverlay;
    }



    
}

