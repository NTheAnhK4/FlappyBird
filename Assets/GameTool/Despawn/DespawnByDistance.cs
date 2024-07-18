using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawner
{
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float disLimit = 70f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = GameObject.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + " Load Camera successful");
    }

    protected override bool CanDespawn()
    {
        Vector3 curPos = transform.parent.position;
        return Vector3.Distance(curPos, mainCam.transform.position) > disLimit;
    }
}
