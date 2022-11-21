using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    [SerializeField]
    private Image level1;
    [SerializeField]
    private Image level2;
    [SerializeField]
    private Image level3;
    [SerializeField]
    private Image level4;
    [SerializeField]
    private Image level5;

    [SerializeField]
    private Color colorPicker = Color.green;



    private void Start()
    {
        ProgressTracker progressTracker = GameObject.Find("LevelProgressTracker").GetComponent<ProgressTracker>();

        if(progressTracker.GetLevel1())
        { 
            level1.color = colorPicker;
        }

        if (progressTracker.GetLevel2())
        {
            level2.color = colorPicker;
        }

        if (progressTracker.GetLevel3())
        {
            level3.color = colorPicker;
        }

        if (progressTracker.GetLevel4())
        {
            level4.color = colorPicker;
        }

        if (progressTracker.GetLevel5())
        {
            level5.color = colorPicker;
        }

    }
}
