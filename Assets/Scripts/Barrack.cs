using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrack : MonoBehaviour
{
    [Header("Barrack Requirements")]
    public int WoodReq = 10;
    public int RockReq = 20;
    public int GoldReq = 15;

    [Header("Soldier Requirements")]
    public int WoodMan = 5;
    public int RockMan = 10;
    public int GoldMan = 0;

    [Header("Soldier Prefab")]
    public GameObject soldier;

    [HideInInspector]
    public bool IsBuilt, spawnReady;
    [HideInInspector]
    public int WoodStock, RockStock, GoldStock;

    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private GameObject buildingBase;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        buildingBase = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        buildingBase.GetComponent<MeshRenderer>().enabled = true;
        meshRenderer.enabled = false;
        meshCollider.enabled = false;

        WoodStock = 0;
        RockStock = 0;
        GoldStock = 0;

        IsBuilt = false;
        spawnReady = false;
    }

    private void BuildCheck()
    {
        if (WoodStock >= WoodReq && RockStock >= RockReq && GoldStock >= GoldReq)
        {
            IsBuilt = true;
            spawnReady = true;
            WoodStock -= WoodReq;
            RockStock -= RockReq;
            GoldStock -= GoldReq;
            RevealBarrack();
        }

    }

    private void Update()
    {
        if (!IsBuilt)
        {
            BuildCheck();
        }
        else if (spawnReady)
        {
            SpawnMan();
        }
    }

    private void SpawnMan()
    {
        if (WoodStock >= WoodMan && RockStock >= RockMan && GoldStock >= GoldMan)
        {
            WoodStock -= WoodMan;
            RockStock -= RockMan;
            GoldStock -= GoldMan;
            Instantiate(soldier, GameManager.SpawnPosition + new Vector3(UnityEngine.Random.Range(-3.0f, 3.0f), 0, UnityEngine.Random.Range(-3.0f, 3.0f)), Quaternion.Euler(0, -90, 0));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.backpack.Count > 0)
        {
            if (!IsBuilt)
            {
                BuildStockCarry(WoodReq, RockReq, GoldReq);
            }
            else if (spawnReady)
            {
                BuildStockCarry(WoodMan, RockMan, GoldMan);
            }
        }
    }

    private void BuildStockCarry(int reqWood, int reqRock, int reqGold)
    {
        for (int i = GameManager.backpack.Count - 1; i >= 0; i--)
        {
            var temp = GameManager.backpack[i];
            ResourceType rType = temp.GetComponent<Block>().resType;
            switch (rType)
            {
                case ResourceType.WOOD:
                    if (reqWood > WoodStock)
                    {
                        WoodStock++;
                        temp.GetComponent<Block>().CollectStock(gameObject, i);
                    }
                    break;
                case ResourceType.ROCK:
                    if (reqRock > RockStock)
                    {
                        RockStock++;
                        temp.GetComponent<Block>().CollectStock(gameObject, i);
                    }
                    break;
                case ResourceType.GOLD:
                    if (reqGold > GoldStock)
                    {
                        GoldStock++;
                        temp.GetComponent<Block>().CollectStock(gameObject, i);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void RevealBarrack()
    {
        meshRenderer.enabled = true;
        meshCollider.enabled = true;
        buildingBase.GetComponent<MeshRenderer>().enabled = false;
    }
}