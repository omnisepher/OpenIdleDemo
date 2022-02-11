using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSource : ResourceMine
{
    private ResourceType resType = ResourceType.WOOD;

    protected override void SpawnBlock()
    {
        block.GetComponent<Block>().resType = resType;
        block.name = "WoodBlock";
        base.SpawnBlock();
    }
}
