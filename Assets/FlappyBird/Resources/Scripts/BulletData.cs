using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "Data/BulletData")]
public class BulletData : ScriptableObject
{
    public List<BulletParameter> bulletDataList;
}

[Serializable]
public class BulletParameter
{
    public string bulletName;
    public int bulletLevel;
    public float damage;
    public float speed;

    public float damageGrowthRate;
    public float speedGrowthRate;
}