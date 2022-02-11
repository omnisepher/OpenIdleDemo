using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ResourceType resType;

    private bool IsMoving = false;

    public void CollectStock(GameObject barrack, int index)
    {
        if (!IsMoving)
        {
            StartCoroutine(MoveBase(barrack, index));
            IsMoving = true;
        }
    }

    IEnumerator MoveBase(GameObject barrack, int index)
    {
        GameManager.backpack.RemoveAt(index);
        while (Vector3.Distance(transform.position, barrack.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, barrack.transform.position, 0.1f); //TODO Time Management
            yield return null;
        }
        Destroy(gameObject);
    }

}
