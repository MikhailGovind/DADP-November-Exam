using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker Instance;
    private bool level1;
    private bool level2;
    private bool level3;
    private bool level4;
    private bool level5;

    private void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(this);
    }

    public bool GetLevel1()
    {
        return level1;
    }

    public bool GetLevel2()
    {
        return level2;
    }

    public bool GetLevel3()
    {
        return level3;
    }
    public bool GetLevel4()
    {
        return level4;
    }

    public bool GetLevel5()
    {
        return level5;
    }
    
    public void SetLevel1(bool b)
    {
        level1 = b;
    }

    public void SetLevel2(bool b)
    {
        level2 = b;
    }

    public void SetLevel3(bool b)
    {
        level3 = b;
    }
    public void SetLevel4(bool b)
    {
        level4 = b;
    }
    public void SetLevel5(bool b)
    {
        level5 = b;
    }
    
}
