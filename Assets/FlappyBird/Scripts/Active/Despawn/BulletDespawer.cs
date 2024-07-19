using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawer : DespawnByTime
{
    protected override void ResetTimeDespawn()
    {
        this.timeDespawn = 1.5f;
    }

    public override void DespawnObject()
    {
        if (!CanDespawn()) return;
        BulletSpawner.Instance.DespawnObject(transform.parent);
    }
}
