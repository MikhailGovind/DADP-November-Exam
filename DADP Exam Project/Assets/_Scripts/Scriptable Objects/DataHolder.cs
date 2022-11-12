using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder<T>: MonoBehaviour
where T : ScriptableObject
{
    [SerializeField]
    private T scriptable;


    public T GetScriptObj()
    {
        return scriptable;
    }


}
