using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BlockData", menuName = "Data/BlockData")]
public class BlockData : ScriptableObject
{
    public List<BlockParameter> blockDataList;
}

[Serializable]
public class BlockParameter
{
    public string blockName;
    public float maxHp;
    public List<Sprite> spritesList;
}
