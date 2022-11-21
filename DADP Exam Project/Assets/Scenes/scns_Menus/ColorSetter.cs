using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

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

    [SerializeField]
    private GameObject winScreen;

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

        if(progressTracker.GetLevel1() && progressTracker.GetLevel2() && progressTracker.GetLevel3() && progressTracker.GetLevel4() && progressTracker.GetLevel5())
        {
            winScreen.SetActive(true);
        }

    }
}
