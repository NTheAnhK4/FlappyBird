using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void LoadComponent()
    {
        
    }

    protected virtual void ResetValue()
    {
        
    }

    
    
}
