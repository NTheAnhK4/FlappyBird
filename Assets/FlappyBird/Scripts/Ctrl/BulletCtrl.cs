using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class BulletCtrl : ComponentBehavior
{
    [SerializeField] protected BulletData data;
    [SerializeField] protected int bulletLevel = 1;
    [SerializeField] protected int bulletIndex;
    [SerializeField] protected BulletMovement bulletMovement;
    [SerializeField] protected BulletDespawer bulletDespawer;
    [SerializeField] protected BulletImpact bulletImpact;
    [SerializeField] protected string source = "Player";
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    public BulletMovement BulletMovement => bulletMovement;

    public BulletDespawer BulletDespawer => bulletDespawer;

    public BulletImpact BulletImpact => bulletImpact;

    public int BulletLevel
    {
        get => bulletLevel;
        set => bulletLevel = value;
    }

    public string Source
    {
        get => source;
        set => source = value;
    }

    public float Damage => damage;

    public float Speed => speed;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadData();
        this.LoadMovement();
        this.LoadDespawner();
        this.LoadImpact();
    }

    protected virtual void LoadData()
    {
        if(data != null) return;
        string resPath = "ScriptableObject/BulletData";
        data = Resources.Load<BulletData>(resPath);
        Debug.Log(transform.name + " LoadData successful");
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

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetBulletIndex();
        this.UpdateInfor();
    }

    protected virtual void ResetBulletIndex()
    {
        if (transform.name == "Green Laser") bulletIndex = 0;
    }
    private void OnEnable()
    {
        UpdateInfor();
    }
    

    protected virtual void UpdateInfor()
    {
        damage = (bulletLevel - data.bulletDataList[bulletIndex].bulletLevel) * data.bulletDataList[bulletIndex].damageGrowthRate + data.bulletDataList[bulletIndex].damage;
        speed = (bulletLevel - data.bulletDataList[bulletIndex].bulletLevel) * data.bulletDataList[bulletIndex].speedGrowthRate + data.bulletDataList[bulletIndex].speed;
        bulletImpact.ResetDamage();
        bulletMovement.ResetSpeed();
    }
    
}
