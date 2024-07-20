using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MoveHorizontal
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        if(bulletCtrl != null)
            Debug.Log(transform.parent.name + " " + transform.name + " Load Ctrl successful");
    }

    public override void ResetSpeed()
    {
        this.speed = bulletCtrl.Speed;
    }

    protected override void ResetDirection()
    {
        this.direction = Vector3.right;
    }
}
