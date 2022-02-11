using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI goldText;
    [SerializeField]
    private TMPro.TextMeshProUGUI rockText;
    [SerializeField]
    private TMPro.TextMeshProUGUI woodText;

    [SerializeField]
    private TMPro.TextMeshProUGUI objectiveText;

    private Barrack barrack;

    private void OnEnable()
    {
        barrack = transform.parent.gameObject.GetComponent<Barrack>();
    }

    private void Update()
    {
        if (!barrack.IsBuilt)
        {
            objectiveText.text = "Build the barrack";
            goldText.text = barrack.GoldReq - barrack.GoldStock + "";
            rockText.text = barrack.RockReq - barrack.RockStock + "";
            woodText.text = barrack.WoodReq - barrack.WoodStock + "";
        }
        else if (barrack.spawnReady)
        {
            objectiveText.text = "Train soldiers";
            goldText.text = barrack.GoldMan - barrack.GoldStock + "";
            rockText.text = barrack.RockMan - barrack.RockStock + "";
            woodText.text = barrack.WoodMan - barrack.WoodStock + "";
        }
    }
}
