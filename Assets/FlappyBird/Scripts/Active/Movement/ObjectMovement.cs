using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MoveHorizontal
{
    protected override void ResetDirection()
    {
        this.direction = Vector3.left;
    }

    public override void ResetSpeed()
    {
        this.speed = 6f;
    }
}
