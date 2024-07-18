using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallSpawner : Spawner<WallSpawner>
{
    [SerializeField] protected Vector3 spawnPos;
    [SerializeField] protected float minTimeSpawn = 5f;
    [SerializeField] protected float maxTimeSpawn = 9f;
    [SerializeField] protected float timeSpawn;
    [SerializeField] protected float coolDown;

    protected override void ResetValue()
    {
        base.ResetValue();
        Init();
    }

    protected virtual void Init()
    {
        timeSpawn = 0;
        coolDown = 0f;
        spawnPos = new Vector3(65, 0, 0);
    }

    protected virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual void UpdatePhysis()
    {
        if(coolDown < timeSpawn) return;
        SpawnWall();
        ResetTime();
    }

    protected virtual void ResetTime()
    {
        coolDown = 0f;
        timeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
    }

    protected virtual void SpawnWall()
    {
        WallSpawner.Instance.Spawn("Wall", spawnPos);
    }

    private void Update()
    {
        this.UpdateLogic();
        this.UpdatePhysis();
    }
}
