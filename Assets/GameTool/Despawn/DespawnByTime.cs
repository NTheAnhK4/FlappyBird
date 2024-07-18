using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timeDespawn = 2f;
    [SerializeField] protected float coolDown = 0f;

    private void OnEnable()
    {
        coolDown = 0f;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetTimeDespawn();
    }

    protected virtual void ResetTimeDespawn()
    {
        
    }

    private void Update()
    {
        UpdateLogic();
        DespawnObject();
    }

    protected virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }
    protected override bool CanDespawn()
    {
        return coolDown >= timeDespawn;
    }
}
