using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceMine : MonoBehaviour
{
    private float timer = 0.0f;

    [SerializeField]
    private Material mat;

    [SerializeField]
    protected GameObject block;

    private GameObject stack;

    private void Start()
    {
        stack = GameObject.FindGameObjectWithTag("Stack");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer >= GameManager.maxTime)
            {
                timer = 0.0f;
                SpawnBlock();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0.0f;
    }

    protected virtual void SpawnBlock()
    {
        GameObject temp = Instantiate(block, stack.transform.position + new Vector3(0, GameManager.backpack.Count * 0.1f, 0), Quaternion.Euler(0, -45, 0));
        temp.transform.SetParent(stack.transform);
        GameManager.backpack.Add(temp);
        temp.GetComponent<MeshRenderer>().sharedMaterial = mat;
    }
}
