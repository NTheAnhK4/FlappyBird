using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : ComponentBehavior
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Block"))
            this.PostEvent(EventID.On_Player_Dead,0);
    }
}
