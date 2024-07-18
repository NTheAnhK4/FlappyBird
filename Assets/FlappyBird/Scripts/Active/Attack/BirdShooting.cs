using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooting : AbstractShooting
{
    

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
}
