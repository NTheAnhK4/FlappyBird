using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BlockDamageReceiver : DamageReceiver
{
    

    protected override void ResetColliderInfor()
    {
        this.boxCollider2D.isTrigger = true;
    }

    protected override void ResetRigid()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }

    protected override void OnDead()
    {
        BlockSpawner.Instance.DespawnObject(transform);
    }

    protected override void ResetMaxHp()
    {
        this.maxHp = 10f;
    }
}
