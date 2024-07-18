using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender 
{
    private float _damage = 1;

    public DamageSender(float damage)
    {
        _damage = damage;
    }
    public void SendDamage(Transform DamageReceiver)
    {
        DamageReceiver damageReceiver = DamageReceiver.GetComponent<DamageReceiver>();
        SendDamage(damageReceiver);
    }

    public void SendDamage(DamageReceiver damageReceiver)
    {
        if(damageReceiver == null) return;
        damageReceiver.Deduct(_damage);
    }
}
