using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI goldText;
    [SerializeField]
    private TMPro.TextMeshProUGUI rockText;
    [SerializeField]
    private TMPro.TextMeshProUGUI woodText;

    private Storage storage;

    private void OnEnable()
    {
        storage = transform.parent.gameObject.GetComponent<Storage>();
    }

    private void Update()
    {
        goldText.text = storage.GoldStock + "";
        rockText.text = storage.RockStock + "";
        woodText.text = storage.WoodStock + "";
    }
}
