using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(JumpCtrl))]
public class PlayerCtrl : ComponentBehavior
{
    [SerializeField] private JumpCtrl _jumpCtrl;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJump();
    }

    protected virtual void LoadJump()
    {
        if(_jumpCtrl != null) return;
        _jumpCtrl = transform.GetComponent<JumpCtrl>();
        Debug.Log(transform.name + " Load Jump successful");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
           _jumpCtrl.Jumping();
    }

   
}
