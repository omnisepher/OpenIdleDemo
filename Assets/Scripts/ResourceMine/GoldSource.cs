using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSource : ResourceMine
{
    private ResourceType resType = ResourceType.GOLD;

    protected override void SpawnBlock()
    {
        block.GetComponent<Block>().resType = resType;
        block.name = "GoldBlock";
        base.SpawnBlock();
    }
}
