using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooting : ComponentBehavior
{
    [SerializeField] protected int bulletLevel;
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
        this.ResetBulletLevel();
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
        ResetBulletInfor(ctrl);
        coolDown = 0f;
    }

    protected virtual void ResetBulletInfor(BulletCtrl ctrl)
    {
        ctrl.Source = source;
        ctrl.BulletLevel = bulletLevel;
    }

    protected virtual void ResetTimeShoot()
    {
        
    }

    public abstract void ResetBulletLevel();
    protected abstract void ResetBulletName();
    protected abstract void ResetQuaternion();
    protected abstract void ResetSource();
}
