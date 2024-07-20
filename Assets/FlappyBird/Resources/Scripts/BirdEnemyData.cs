using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BirdEnemyData", menuName = "Data/BirdEnemyData")]
public class BirdEnemyData : ScriptableObject
{
    public List<BirdEnemyParameter> birdEnemyData;
}

[Serializable]
public class BirdEnemyParameter
{
    public string name;
    public int level;
    public float speed;
    public float maxHp;
    public float attackSpeed;

    public float speedGrowthRate;
    public float maxHpGrowthRate;
    public float attackSpeedGrowthRate;
}
