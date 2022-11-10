using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridController: MonoBehaviour
{

    [SerializeField]
    private GridManager gridManager;

    [field:SerializeField]
    internal CustomGrid currentGrid { get; private set; }
    
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


    private void Start()
    {
        overlaySwitch = EnableDebugOverlay;
        
        
    }

}

