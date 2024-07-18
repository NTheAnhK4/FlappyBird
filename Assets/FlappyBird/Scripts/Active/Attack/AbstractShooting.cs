using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooting : ComponentBehavior
{
    [SerializeField] protected float timeShoot = 0.5f;
    [SerializeField] protected float coolDown = 0f;
    [SerializeField] protected string bulletName;
    [SerializeField] protected Quaternion quaternion;
    [SerializeField] protected string source;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetBulletName();
        this.ResetQuaternion();
        this.ResetTimeShoot();
        this.ResetSource();
    }

    private void Update()
    {
        UpdateLogic();
        UpdatePhysis();
    }

    protected virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual void UpdatePhysis()
    {
        if(coolDown < timeShoot) return;
       
        BulletCtrl ctrl = BulletSpawner.Instance.Spawn(bulletName, transform.position, quaternion).GetComponent<BulletCtrl>();
        ctrl.Source = source;
        coolDown = 0f;
    }

    protected virtual void ResetTimeShoot()
    {
        
    }
    protected abstract void ResetBulletName();
    protected abstract void ResetQuaternion();
    protected abstract void ResetSource();
}
