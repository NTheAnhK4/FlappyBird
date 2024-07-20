
using UnityEngine;

public class DamageSender 
{
    private float _damage;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }
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
