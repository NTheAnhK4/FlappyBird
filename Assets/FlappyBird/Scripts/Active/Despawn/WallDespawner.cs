using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDespawner : DespawnByDistance
{
    public override void DespawnObject()
    {
        Transform blockHolder = transform.parent.Find("CreateBlock");
        foreach (Transform obj in blockHolder)
        {
            BlockSpawner.Instance.DespawnObject(obj);
        }
        WallSpawner.Instance.DespawnObject(transform.parent);
    }
}
