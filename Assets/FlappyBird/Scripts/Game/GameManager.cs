using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ComponentBehavior
{
   [SerializeField] protected Vector3 spawnPos;
   [SerializeField] protected float minTimeSpawn = 3f;
   [SerializeField] protected float maxTimeSpawn = 7f;
   [SerializeField] protected float timeSpawn;
   [SerializeField] protected float coolDown;
   
   protected override void ResetValue()
   {
      base.ResetValue();
      Init();
   }

   protected virtual void Init()
   {
      this.minTimeSpawn = 4;
      this.maxTimeSpawn = 8;
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
      int type = Random.Range(0, 5);
      if(type <= 3)
         SpawnWall();
      else SpawnCoin();
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

   protected virtual void SpawnCoin()
   {
      float PosY = Random.Range(-13, 13);
      for (int i = -1; i <= 1; ++i)
      {
         int row = Random.Range(0, 8);
         for (int j = 0; j < 3; ++j)
         {
            if (((1 << j) & i) != 0)
            {
               Vector3 newPos = new Vector3(-3.0f * (j - 1) + spawnPos.x, i * -3.0f + PosY, spawnPos.z);
               CoinSpawner.Instance.SpawnRandomObject(newPos);
            }
         }
      }
   }

   private void Update()
   {
      this.UpdateLogic();
      this.UpdatePhysis();
   }
}
