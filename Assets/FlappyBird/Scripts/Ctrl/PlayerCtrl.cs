using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(JumpCtrl))]
public class PlayerCtrl : BirdCtrl
{
    
    [SerializeField] private JumpCtrl _jumpCtrl;
    [SerializeField] private BirdShooting birdShooting;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJump();
        this.LoadAttack();
    }

    
    protected virtual void LoadJump()
    {
        if(_jumpCtrl != null) return;
        _jumpCtrl = transform.GetComponent<JumpCtrl>();
        Debug.Log(transform.name + " Load Jump successful");
    }

    protected virtual void LoadAttack()
    {
        if (birdShooting != null) return;
        birdShooting = transform.GetComponentInChildren<BirdShooting>();
        Debug.Log(transform.name + " LoadAttack successful");
    }
    private void Update()
    {
        _jumpCtrl.ChangePos();
        if(Input.GetKeyDown(KeyCode.Space))
           _jumpCtrl.Jumping();
       
    }

    public override void ResetBirdLevel()
    {
        base.ResetBirdLevel();
        birdShooting.ResetBulletLevel();
    }
}
