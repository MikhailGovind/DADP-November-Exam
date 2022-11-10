using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class RoughTile : BasicTile
{
    [SerializeField]
    private bool Walkable;

    [SerializeField]
    private bool Pit;

    [SerializeField]
    private GameObject UnitSlot;

    [SerializeField]
    private GameObject debugTextContainer;


    public void Init(bool isOffset)
    {
        if(!Pit)
        { 
            spriteRenderer.color = isOffset ? offsetColor : baseColor; 
        }
        
    }

    public string getDebugText()
    {
        return debugTextContainer.GetComponent<TextMeshProUGUI>().text;
    }

    public void setDebugText(string change, bool show)
    {
        debugTextContainer.SetActive(true);
        debugTextContainer.GetComponent<TextMeshPro>().text = change;
        if (!show) { debugTextContainer.SetActive(false); }
    }


    public void DebugText()
    {
        if (debugTextContainer.activeSelf)
        {
            debugTextContainer.SetActive(false);
        }
        else
        {
            debugTextContainer.SetActive(true);
        }


    }

    private void OnMouseEnter()
    {
        if(Walkable)
        {
            highlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if(Walkable)
        {
            highlight.SetActive(false);
        }
    }

    
}
