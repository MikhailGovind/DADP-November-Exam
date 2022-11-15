using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;
using System.Net.Http.Headers;

public class PathData : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro PathText;

    [SerializeField]
    private Vector2 pathNode = new Vector2(100, 100);

    public Vector2 pathVector()
    {
        return pathNode;
    }

    public string pathText()
    {
        return PathText.text;
    }

    public void setPathVector(Vector2 data)
    {
        pathNode = data;
        setPathText(data.ToString());
    }

    public void setPathText(string data)
    {
        PathText.text = data;
    }

}


    
