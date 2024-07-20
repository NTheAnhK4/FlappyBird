using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooting : AbstractShooting
{
    [SerializeField] protected BirdCtrl birdCtrl;
    protected override void Awake()
    {
        base.Awake();
        this.AddListener(EventID.On_Player_Level_Change,param=>ResetBulletLevel((int)param));
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if(birdCtrl != null) return;
        birdCtrl = transform.parent.GetComponent<BirdCtrl>();
        if(birdCtrl != null) Debug.Log(transform.parent.name + " " + transform.name + " Load Ctrl successful");
    }
    

    protected override void ResetBulletName()
    {
        this.bulletName = "Green Laser";
    }

    protected override void ResetQuaternion()
    {
        this.quaternion = Quaternion.Euler(0f,0f,0f);
    }

    protected override void ResetTimeShoot()
    {
        this.timeShoot = 0.2f;
    }

    protected override void ResetSource()
    {
        this.source = "Player";
    }

    public override void ResetBulletLevel(int param)
    {
        this.bulletLevel = birdCtrl.BirdLevel;
    }
}
