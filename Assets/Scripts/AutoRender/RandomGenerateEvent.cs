using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerateEvent : MonoBehaviour
{
    private int supplyCount = 5;
    private int enemyCount = 2;
    private int emptyCount = 0; // 默认为 0，可以根据需要进行修改
    private int zombieCount = 3;
    private int gamePropsCount = 5;
    private int trapCount = 2;

    private List<string> eventTypes = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateEvents();
        PrintGeneratedEvents();
    }

    // 随机生成事件
    private void GenerateEvents()
    {
        // 根据每个种类的数量随机生成事件
        GenerateEventsOfType("Supply", supplyCount);
        GenerateEventsOfType("Enemy", enemyCount);
        GenerateEventsOfType("Empty", emptyCount);
        GenerateEventsOfType("Zombie", zombieCount);
        GenerateEventsOfType("Game Props", gamePropsCount);
        GenerateEventsOfType("Trap", trapCount);
    }

    // 根据种类和数量生成事件
    private void GenerateEventsOfType(string eventType, int count)
    {
        for (int i = 0; i < count; i++)
        {
            eventTypes.Add(eventType);
        }
    }

    // 输出生成的事件
    private void PrintGeneratedEvents()
    {
        foreach (string eventType in eventTypes)
        {
            Debug.Log("Generated event: " + eventType);
        }
    }
}
