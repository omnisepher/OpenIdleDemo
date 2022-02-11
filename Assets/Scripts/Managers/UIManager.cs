using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI goldText;
    [SerializeField]
    private TMPro.TextMeshProUGUI rockText;
    [SerializeField]
    private TMPro.TextMeshProUGUI woodText;
    [SerializeField]
    private TMPro.TextMeshProUGUI statusText;

    private void Start()
    {
        statusText.enabled = false;
    }

    private void Update()
    {
        if (GameManager.IsWon)
        {
            statusText.enabled = true;
        }
        goldText.text = "" + GameManager.GoldAmount;
        rockText.text = "" + GameManager.RockAmount;
        woodText.text = "" + GameManager.WoodAmount;
    }
}
