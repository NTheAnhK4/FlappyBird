using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : ComponentBehavior
{
  
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected float speed;

    
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetDirection();
        this.ResetSpeed();
          
    }
    
    protected virtual void ResetDirection()
    {
        this.direction = Vector3.right;
    }

    public virtual void ResetSpeed()
    {
        this.speed = 50; 
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
}
