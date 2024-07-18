using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MoveHorizontal
{
    protected override void ResetSpeed()
    {
        this.speed = 40f;
    }

    protected override void ResetDirection()
    {
        this.direction = Vector3.right;
    }
}
