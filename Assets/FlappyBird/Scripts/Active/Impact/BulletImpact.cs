using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpact : ComponentBehavior
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rb;
    protected DamageSender damageSender;
    [SerializeField] protected float damage = 1f;
    protected override void Awake()
    {
        base.Awake();
        damageSender = new DamageSender(damage);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider();
        this.LoadRigid();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.parent.name + " " + transform.name + " Load Ctrl successful");
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
        boxCollider2D.isTrigger = true;
        boxCollider2D.offset = new Vector2(0, 0);
        boxCollider2D.size = new Vector2(2, 1);
    }

    protected virtual void ResetRigid()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        damageSender.SendDamage(other.transform);
        if (!other.CompareTag(bulletCtrl.Source))
            BulletSpawner.Instance.DespawnObject(transform.parent);
            
    }
}
