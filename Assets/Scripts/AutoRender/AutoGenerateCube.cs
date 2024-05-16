using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerateCube : MonoBehaviour
{
    [SerializeField]
    private GameObject roadPrefabStart;
    [SerializeField]
    private GameObject roadPrefabDestination;
    [SerializeField]
    public GameObject playerPrefab; // 玩家的Prefab
    [SerializeField]
    private int roadLength;
    [SerializeField]
    private int firstRoadLength;
    [SerializeField]
    private float distanceBetweenCubes = 1.0f;
    [SerializeField]
    private int days;
    private List<Vector3> roadPositions = new List<Vector3>(); // 记录路线坐标

    // 各种事件的数量
    private int supplyCount = 5;
    private int enemyCount = 2;
    private int emptyCount = 7;
    private int zombieCount = 3;
    private int gamePropsCount = 5;
    private int trapCount = 2;
    [SerializeField]
    private List<string> eventTypes = new List<string>(); // 存储每个roadPrefabStart的属性类型

    // Start is called before the first frame update
    void Start()
    {
        roadPrefabStart = transform.Find("Start").gameObject;
        roadPrefabDestination = transform.Find("Destination").gameObject;
        days = 3;
        firstRoadLength = 25;
        roadLength = firstRoadLength + days * 24;

        if (roadPrefabStart == null || roadPrefabDestination == null)
        {
            return;
        }

        // 在事件类型列表的第一个位置添加 "Start"
        eventTypes.Add("Start");

        // 生成路线并记录坐标
        Vector3 spawnPosition = transform.position;
        for (int i = 0; i < roadLength; i++)
        {
            int offsetX = UnityEngine.Random.Range(0, 2);
            int offsetZ = offsetX == 0 ? 1 : 0;

            Vector3 offset = new Vector3(offsetX, 0, offsetZ);

            spawnPosition += offset * distanceBetweenCubes;
            roadPositions.Add(spawnPosition); // 记录坐标

            GameObject instance = Instantiate(roadPrefabStart, spawnPosition, Quaternion.identity);
            instance.SetActive(true);
            instance.transform.SetParent(transform, false);

            // 为每个roadPrefabStart分配随机属性类型，并存储到eventTypes列表中
            string eventType = GetRandomEventType();
            eventTypes.Add(eventType);
        }

        // 生成玩家并设置为路线的子物体
        if (playerPrefab != null && roadPositions.Count > 0)
        {
            Vector3 playerSpawnPosition = roadPositions[0]; // 第一个路线位置
            playerSpawnPosition.y += 1; // 玩家位于路线上方
            GameObject playerInstance = Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
            playerInstance.transform.SetParent(transform); // 将玩家设为路线的子物体
        }
    }

    // 获取随机属性类型
    private string GetRandomEventType()
    {
        int randomIndex = UnityEngine.Random.Range(0, 7); // 生成0到5之间的随机索引
        switch (randomIndex)
        {
            case 0:
                return "Supply";
            case 1:
                return "Enemy";
            case 2:
                return "Empty";
            case 3:
                return "Zombie";
            case 4:
                return "Game Props";
            case 5:
                return "Trap";
            case 6:
                return "Empty";
            default:
                return "Default";
        }
    }

    // 生成随机目的地位置
    private Vector3 GenerateRandomDestination()
    {
        int randomX = UnityEngine.Random.Range(0, 25);
        int randomZ = 24 - randomX;
        return new Vector3(randomX, 0, randomZ);
    }

    public List<Vector3> RoadPositions // 声明RoadPositions属性
    {
        get { return roadPositions; } // 返回roadPositions列表
    }

    // 获取人物当前所在 RoadPrefab 的属性类型
    public string GetPlayerCurrentRoadPrefabType(Transform playerTransform)
    {
        // 遍历记录的路线位置
        for (int i = 0; i < roadPositions.Count; i++)
        {
            // 检查是否有路线位置与人物当前位置近似
            if (Vector3.Distance(playerTransform.position, roadPositions[i]) < 1.1f)
            {
                // 获取当前位置对应的 RoadPrefab 的属性类型
                if (i < eventTypes.Count)
                {
                    return eventTypes[i];
                }
                break;
            }
        }
        return "Unknown";
    }

    public string GetAllTypeAmount()
    {
        string result = $"Supply Count: {supplyCount}\n" +
                    $"Enemy Count: {enemyCount}\n" +
                    $"Empty Count: {emptyCount}\n" +
                    $"Zombie Count: {zombieCount}\n" +
                    $"Game Props Count: {gamePropsCount}\n" +
                    $"Trap Count: {trapCount}";

        return result;
    }
}
