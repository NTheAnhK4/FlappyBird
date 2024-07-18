using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : ComponentBehavior
{
    protected abstract bool CanDespawn();

    public virtual void DespawnObject()
    {
        if(!CanDespawn()) return;
        Destroy(transform.parent);
    }
}
