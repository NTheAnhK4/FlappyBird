using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateBlock : ComponentBehavior
{
    [SerializeField] protected float size;
    private float blockMinHeight = 3f;
    private float[] height = new float[4];
    private float[] posY = new float[4];

    private void OnEnable()
    {
        size = Camera.main.orthographicSize;
        size *= 2;
        CreateBlocks();
    }

    private void CalculateBlockInfor()
    {
        float sum = 3 * blockMinHeight;
        float index = size / 2;
        for (int i = 0; i < 3; ++i)
        {
            height[i] = Random.Range(blockMinHeight, size - sum);
            sum += height[i] - blockMinHeight;
            posY[i] = index - height[i] / 2;
            index = posY[i] - height[i]/2;
        }

        height[3] = size - sum;
        posY[3] = index - height[3] / 2;
    }

    private Transform CreateRandomBlock(int index)
    {
        int type = Random.Range(0, 3);
        string blockType = "WoodBlock";
        if (type == 1) blockType = "StoneBlock";
        if (type == 2) blockType = "MetalBlock";
        return  BlockSpawner.Instance.Spawn(blockType, new Vector3(65,posY[index],0), transform);

        
    }
    private void CreateBlocks()
    {
        this.CalculateBlockInfor();
        int type = Random.Range(0, 17);
        for (int i = 0; i < 4; ++i)
        {
            if ((type & (1 << i)) == 0) continue;
            Transform block = CreateRandomBlock(i);
            SetBlockInfor(i,block);
        }
    }

    private void SetBlockInfor(int index, Transform block)
    {
        SpriteRenderer sr = block.GetComponent<SpriteRenderer>();
        sr.size = new Vector2(3, height[index]);
       
        
        BoxCollider2D boxCollider2D = block.GetComponent<BoxCollider2D>();
        boxCollider2D.size = sr.size;
        boxCollider2D.offset = Vector2.zero;
    }
}
