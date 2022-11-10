using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUtilities
{
    private static GameObject Parent;


    public static void SetOverlayParent(GameObject p)
    {
        Parent = p;
    }

    public static TextMesh CreateBasicOverlay(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        if (parent != null)
        {
            return CreateDevOverlay(parent.gameObject, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }
        return CreateDevOverlay(Parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }


    public static TextMesh CreateDevOverlay(GameObject parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject devOverlay = new GameObject("DevOverlay", typeof(TextMesh));
        devOverlay.transform.SetParent(parent.transform, false);
        
        devOverlay.transform.localPosition = localPosition;
        TextMesh overlay = devOverlay.GetComponent<TextMesh>();
        overlay.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        overlay.anchor = textAnchor;
        overlay.alignment = textAlignment;
        overlay.fontSize = fontSize;
        overlay.color = color;
        overlay.text = text;
       
        return overlay;
    }





}
