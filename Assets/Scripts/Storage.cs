using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [HideInInspector]
    public int WoodStock, RockStock, GoldStock;

    private void Start()
    {
        WoodStock = 0;
        RockStock = 0;
        GoldStock = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.backpack.Count > 0)
        {
            BuildStockCarry();
        }
    }

    private void BuildStockCarry()
    {
        for (int i = GameManager.backpack.Count - 1; i >= 0; i--)
        {
            var temp = GameManager.backpack[i];
            ResourceType rType = temp.GetComponent<Block>().resType;
            switch (rType)
            {
                case ResourceType.WOOD:
                    WoodStock++;
                    temp.GetComponent<Block>().CollectStock(gameObject, i);
                    break;
                case ResourceType.ROCK:
                    RockStock++;
                    temp.GetComponent<Block>().CollectStock(gameObject, i);
                    break;
                case ResourceType.GOLD:
                    GoldStock++;
                    temp.GetComponent<Block>().CollectStock(gameObject, i);
                    break;
                default:
                    break;
            }
        }
    }

}
