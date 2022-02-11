using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    WOOD, ROCK, GOLD
}

public class GameManager : MonoBehaviour
{
    public static Vector3 SpawnPosition = new Vector3(-7.5f, 0, 0);

    public static int WoodAmount = 0;
    public static int RockAmount = 0;
    public static int GoldAmount = 0;

    public static int ArcherCount = 0;
    public static int PaladinCount = 0;

    public static float maxTime = 0.1f;
    public static float speed = 10.0f;

    public static List<GameObject> backpack = new List<GameObject>();

    private GameObject stack;
    public static bool IsWon;

    private void Start()
    {
        IsWon = false;

        stack = GameObject.FindGameObjectWithTag("Stack");
    }

    private void Update()
    {
        WinConditionCheck();

        WoodAmount = 0;
        RockAmount = 0;
        GoldAmount = 0;
        for (int i = 0; i < backpack.Count; i++)
        {
            backpack[i].transform.position = stack.transform.position + new Vector3(0, i * 0.1f, 0);
            backpack[i].transform.rotation = Quaternion.Euler(0, 45, 0);
            string name = backpack[i].gameObject.name;
            if (name.Contains("Wood"))
            {
                WoodAmount++;
            }
            else if (name.Contains("Rock"))
            {
                RockAmount++;
            }
            else if (name.Contains("Gold"))
            {
                GoldAmount++;
            }
        }
    }

    private void WinConditionCheck()
    {
        ArcherCount = GameObject.FindGameObjectsWithTag("Archer").Length;
        PaladinCount = GameObject.FindGameObjectsWithTag("Paladin").Length;
        if (ArcherCount >= 3 && PaladinCount >= 3)
        {
            IsWon = true;
            speed = 0.0f;
        }
    }

}
