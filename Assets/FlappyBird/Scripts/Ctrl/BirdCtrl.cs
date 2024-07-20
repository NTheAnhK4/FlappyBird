using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : ComponentBehavior
{
    [SerializeField] protected int birdLevel;

    public int BirdLevel
    {
        get => birdLevel;
        set => birdLevel = value;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetBirdLevel();
    }

    public virtual void ResetBirdLevel()
    {
        birdLevel = 1;
    }
}
