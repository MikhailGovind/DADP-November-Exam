using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField]
    private CommentsExample example;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(example.MySum(0, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
