using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private int a = 5;
    public int b
    {
        get => a;
        set { b = value;}
    }
    void Start()
    {
        
    }
    void Plus(int value)
    {
        value += 2;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Plus(b);
        }
    }
}
