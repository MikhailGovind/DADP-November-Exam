using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayGridMaker : MonoBehaviour
{

    private void Start()
    {
        CustomGridMap.SetOverlayParent(this.gameObject);
        CustomGridMap gridOverlay = new CustomGridMap(12, 12, 89);

    }
    

    

}
