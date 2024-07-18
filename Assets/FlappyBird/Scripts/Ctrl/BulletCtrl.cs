using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ComponentBehavior
{
    [SerializeField] protected BulletMovement bulletMovement;
    [SerializeField] protected BulletDespawer bulletDespawer;
    [SerializeField] protected BulletImpact bulletImpact;
    [SerializeField] protected string source = "Player";
    public BulletMovement BulletMovement => bulletMovement;

    public BulletDespawer BulletDespawer => bulletDespawer;

    public BulletImpact BulletImpact => bulletImpact;

    public string Source
    {
        get => source;
        set => source = value;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadDespawner();
        this.LoadImpact();
    }

    protected virtual void LoadMovement()
    {
        if(bulletMovement != null) return;
        bulletMovement = transform.GetComponentInChildren<BulletMovement>();
        Debug.Log(transform.name + " Load Movement successful");
    }
    protected virtual void LoadDespawner()
    {
        if(bulletDespawer != null) return;
        bulletDespawer = transform.GetComponentInChildren<BulletDespawer>();
        Debug.Log(transform.name + " Load Despawner successful");
    }
    protected virtual void LoadImpact()
    {
        if(bulletImpact != null) return;
        bulletImpact = transform.GetComponentInChildren<BulletImpact>();
        Debug.Log(transform.name + " Load Impact successful");
    }
}
