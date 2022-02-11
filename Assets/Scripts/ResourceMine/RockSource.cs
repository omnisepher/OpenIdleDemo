using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSource : ResourceMine
{
    private ResourceType resType = ResourceType.ROCK;

    protected override void SpawnBlock()
    {
        block.GetComponent<Block>().resType = resType;
        block.name = "RockBlock";
        base.SpawnBlock();
    }
}
