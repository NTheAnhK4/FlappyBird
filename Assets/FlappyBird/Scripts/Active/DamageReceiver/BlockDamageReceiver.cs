using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDamageReceiver : DamageReceiver
{
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] protected BlockData data;
    [SerializeField] protected int blockIndex;
    [SerializeField] protected AudioSource hitBlock;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadData();
        this.LoadSprite();
        this.LoadSound();
    }
    
    protected virtual void LoadData()
    {
        if (data != null) return;
        string resPath = "ScriptableObject/BlockData";
        data = Resources.Load<BlockData>(resPath);
        Debug.Log(transform.name + " LoadData successful");
    }

    protected virtual void LoadSprite()
    {
        if (sr != null) return;
        sr = transform.GetComponent<SpriteRenderer>();
        if(sr != null)
            Debug.Log(transform.name + " Load Sprite successful");
    }
    protected override void ResetColliderInfor()
    {
        this.boxCollider2D.isTrigger = true;
    }

    protected override void ResetRigid()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }

    protected virtual void LoadSound()
    {
        if (hitBlock != null) return;
        hitBlock = transform.GetComponentInChildren<AudioSource>();
        if(hitBlock != null) Debug.Log(transform.name + " Load Sound succesful");
    }
   
    protected override void OnDead()
    {
        float add = (float)(blockIndex + 1);
        this.PostEvent(EventID.On_Player_Add_EXP,add);
        sr.sprite = data.blockDataList[blockIndex].spritesList[0];
        BlockSpawner.Instance.DespawnObject(transform);
    }

    protected void ResetBlockIndex()
    {
        if (transform.name == "WoodBlock") blockIndex = 0;
        if (transform.name == "StoneBlock") blockIndex = 1;
        if (transform.name == "MetalBlock") blockIndex = 2;
    }
    protected override void ResetMaxHp()
    {
        this.ResetBlockIndex();
        this.maxHp = data.blockDataList[blockIndex].maxHp;
    }

    public override void Deduct(float damage)
    {
        curHp -= damage;
        if (curHp / maxHp <= 1.0 / 3) sr.sprite = data.blockDataList[blockIndex].spritesList[2];
        else if(curHp / maxHp <= 2.0/3) sr.sprite = data.blockDataList[blockIndex].spritesList[1];
        else sr.sprite = data.blockDataList[blockIndex].spritesList[0];
        if (curHp <= 0)
        {
            curHp = 0;
            OnDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
            hitBlock.Play();
    }
}
