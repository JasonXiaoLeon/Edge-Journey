using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private List<UnityEngine.Vector3> roadPositions = new List<UnityEngine.Vector3>(); // 记录路线坐标

    // Start is called before the first frame update
    void Start()
{
    roadPrefabStart = transform.Find("Start").gameObject;
    roadPrefabDestination = transform.Find("Destination").gameObject;
    days = 3;
    firstRoadLength = 25;
    roadLength = firstRoadLength + days*24;

    if (roadPrefabStart == null || roadPrefabDestination == null)
    {
        return;
    }

    // 生成路线并记录坐标
    UnityEngine.Vector3 spawnPosition = transform.position;
    for (int i = 0; i < roadLength; i++)
    {
        int offsetX = Random.Range(0, 2);
        int offsetZ = offsetX == 0 ? 1 : 0;

        UnityEngine.Vector3 offset = new UnityEngine.Vector3(offsetX, 0, offsetZ);

        spawnPosition += offset * distanceBetweenCubes;
        roadPositions.Add(spawnPosition); // 记录坐标

        GameObject instance = Instantiate(roadPrefabStart, spawnPosition, UnityEngine.Quaternion.identity);
        instance.SetActive(true);
        instance.transform.SetParent(transform, false);
    }

    // 生成玩家并设置为路线的子物体
    if (playerPrefab != null && roadPositions.Count > 0)
    {
        UnityEngine.Vector3 playerSpawnPosition = roadPositions[0]; // 第一个路线位置
        playerSpawnPosition.y += 1; // 玩家位于路线上方
        GameObject playerInstance = Instantiate(playerPrefab, playerSpawnPosition, UnityEngine.Quaternion.identity);
        playerInstance.transform.SetParent(transform); // 将玩家设为路线的子物体
    }
}

    // Update is called once per frame
    void Update()
    {

    }

    // 生成随机目的地位置
    private UnityEngine.Vector3 GenerateRandomDestination()
    {
        int randomX = Random.Range(0, 25);
        int randomZ = 24 - randomX;
        return new UnityEngine.Vector3(randomX, 0, randomZ);
    }

    public List<Vector3> RoadPositions // 声明RoadPositions属性
    {
        get { return roadPositions; } // 返回roadPositions列表
    }
}
