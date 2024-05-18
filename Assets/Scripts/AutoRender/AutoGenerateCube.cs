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
    public GameObject buildingPrefab; // 建筑物的Prefab
    [SerializeField]
    public GameObject DestroyPrefab; // 石头的Prefab
    [SerializeField]
    public GameObject lampPrefab; // 石头的Prefab
    [SerializeField]
    public GameObject treePrefab; // 树的Prefab
    [SerializeField]
    public GameObject carPrefab; // 车的Prefab

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
    private int emptyCount = 5;
    private int shopCount = 2;
    private int zombieCount = 3;
    private int gamePropsCount = 5;
    private int trapCount = 2;

    [SerializeField]
    private List<string> eventTypes = new List<string>(); // 存储每个roadPrefabStart的属性类型

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

        // 生成每24个为一组的事件类型并打乱
        GenerateAndShuffleEvents();

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
            if (i < eventTypes.Count)
            {
                // 这里可以根据eventTypes的值来生成对应的对象
                string eventType = eventTypes[i];
                // 这里可以根据eventType来生成不同的物体
            }

            // 根据条件生成物体
            if ((i + 1) % 8 == 0 && buildingPrefab != null)
            {
                GenerateObject(buildingPrefab, instance, roadPositions[i], new Vector3(8, -1, -8));
                GenerateObject(DestroyPrefab, instance, roadPositions[i], new Vector3(4, -1, -4));
                GenerateObject(lampPrefab, instance, roadPositions[i], new Vector3(2, -1, -2));
            }
            if ((i + 1) % 24 == 0 && buildingPrefab != null)
            {
                GenerateObject(carPrefab, instance, roadPositions[i], new Vector3(-3, 0, 3));
            }
            if ((i + 1) % 11 == 0 && buildingPrefab != null)
            {
                GenerateObject(buildingPrefab, instance, roadPositions[i], new Vector3(-8, -1, 8), new Vector3(0, -90, 0));
                GenerateObject(DestroyPrefab, instance, roadPositions[i], new Vector3(-4, -1, 4));
                GenerateObject(lampPrefab, instance, roadPositions[i], new Vector3(-1, -1, 1));
            }
            if ((i + 1) % 3 == 0 && treePrefab != null)
            {
                GenerateObject(treePrefab, instance, roadPositions[i], new Vector3(-4, -1, 4));
                GenerateObject(treePrefab, instance, roadPositions[i], new Vector3(4, -1, -4));
            }
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

    // 创建并打乱事件类型列表
    private void GenerateAndShuffleEvents()
    {
        int eventGroupCount = roadLength / 24; // 每 24 个为一组
        for (int group = 0; group < eventGroupCount; group++)
        {
            List<string> events = new List<string>();

            // 按照指定数量添加事件类型
            for (int i = 0; i < supplyCount; i++) events.Add("Supply");
            for (int i = 0; i < enemyCount; i++) events.Add("Enemy");
            for (int i = 0; i < emptyCount; i++) events.Add("Empty");
            for (int i = 0; i < shopCount; i++) events.Add("Shop");
            for (int i = 0; i < zombieCount; i++) events.Add("Zombie");
            for (int i = 0; i < gamePropsCount; i++) events.Add("Game Props");
            for (int i = 0; i < trapCount; i++) events.Add("Trap");

            // 打乱事件类型列表
            for (int i = 0; i < events.Count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, events.Count);
                string temp = events[i];
                events[i] = events[randomIndex];
                events[randomIndex] = temp;
            }

            // 添加打乱后的事件类型到eventTypes
            eventTypes.AddRange(events);
        }
    }

    // 生成随机物体的方法
    private void GenerateObject(GameObject prefab, GameObject parent, Vector3 position, Vector3 offset, Vector3? rotation = null)
    {
        Vector3 spawnPosition = position + offset;
        Quaternion spawnRotation = rotation.HasValue ? Quaternion.Euler(rotation.Value) : Quaternion.identity;
        GameObject instance = Instantiate(prefab, spawnPosition, spawnRotation);
        instance.transform.SetParent(parent.transform);
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
    public string GetPlayerRoadPrefabType(Transform playerTransform, bool getNext = false)
    {
        int currentIndex = -1;

        // 查找当前位置索引
        for (int i = 0; i < roadPositions.Count; i++)
        {
            if (Vector3.Distance(playerTransform.position, roadPositions[i]) < 1.1f)
            {
                currentIndex = i;
                break;
            }
        }

        if (currentIndex == -1)
        {
            return "Unknown"; // 如果找不到匹配的路线位置，返回 Unknown
        }

        // 根据参数决定返回当前位置或下一个位置的属性类型
        if (!getNext)
        {
            // 返回当前位置的属性类型
            if (currentIndex < eventTypes.Count)
            {
                return eventTypes[currentIndex];
            }
        }
        else
        {
            // 返回下一个位置的属性类型
            int nextIndex = (currentIndex + 1) % roadPositions.Count; // 循环获取下一个位置的索引
            if (nextIndex < eventTypes.Count)
            {
                return eventTypes[nextIndex];
            }
        }

        return "Unknown"; // 默认情况下返回 Unknown
    }

    public string GetAllTypeAmount()
    {
        return $"Supply: {supplyCount}\n" +
               $"Enemy: {enemyCount}\n" +
               $"Empty: {emptyCount}\n" +
               $"Zombie: {zombieCount}\n" +
               $"Game Props: {gamePropsCount}\n" +
               $"Trap: {trapCount}\n" +
               $"Shop: {shopCount}";
    }
}
