using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class DamageReceiver : ComponentBehavior
{
    
    
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        
        this.LoadBoxCollider();
        this.LoadRigid();
    }

    
    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.ResetColliderInfor();
        Debug.Log(transform.parent.name + " LoadBoxCollider successful");
    }

    protected virtual void LoadRigid()
    {
        if(this.rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
        this.ResetRigid();
        Debug.Log(transform.parent.name + " LoadRigid successful");
    }

    protected virtual void ResetColliderInfor()
    {
        
    }

    protected virtual void ResetRigid()
    {
        
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetMaxHp();
        this.curHp = maxHp;
    }

    protected virtual void ResetMaxHp()
    {
    }

   

    protected void OnEnable()
    {
        curHp = maxHp;
    }

    public virtual void Deduct(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            OnDead();
        }
    }

    

    protected virtual void OnDead()
    {
        
    }
}
