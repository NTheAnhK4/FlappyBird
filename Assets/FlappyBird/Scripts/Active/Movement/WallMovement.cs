using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MoveHorizontal
{
    protected override void ResetDirection()
    {
        this.direction = Vector3.left;
    }

    protected override void ResetSpeed()
    {
        this.speed = 6f;
    }
}
