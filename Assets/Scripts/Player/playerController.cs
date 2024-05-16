using System;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float moveSpeed = 5f; // 移动速度
    private Vector3 currentDestination; // 将 Vector3 改为 UnityEngine.Vector3
    private int currentDestinationIndex = 0; // 当前目标位置索引
    private bool isMoving = false; // 是否正在移动
    private AutoGenerateCube autoGenerateCube; // 存储AutoGenerateCube的引用
    public Light directionalLight; // Directional Light 引用
    private SoundEffect soundEffect; // SoundEffect 脚本引用
    private Action actionScript; // Action 脚本引用
    private ResourceManage apManage;
    private ActionUI actionUI;

    void Start()
    {
        autoGenerateCube = FindObjectOfType<AutoGenerateCube>(); // 在场景中查找并获取AutoGenerateCube的实例
        directionalLight = GameObject.FindObjectOfType<Light>();
        actionScript = GetComponent<Action>(); // 获取挂载在同一物体上的 Action 脚本引用
        soundEffect = GameObject.Find("SoundSystem").GetComponent<SoundEffect>(); // 获取 SoundEffect 组件
        apManage = GameObject.Find("行动").GetComponent<ResourceManage>();
        actionUI = GameObject.Find("行动阶段").GetComponent<ActionUI>();
    }

    void Update()
    {
        // 当按下空格键时，开始移动
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 检查 actionPoint 是否大于 0
            if (actionScript.GetBiochemistryPoint() != 0 )
            {
                // 减少 actionPoint 的值
                if (actionScript.GetMoveAmount() >0)
                {
                    actionScript.SetMoveAmountDecreaseByOne();
                    StartMoving();
                } 
            }
        }

        // 如果正在移动，执行移动逻辑
        if (isMoving)
        {
            MoveToDestination();
        }
        //else
        //{
        //    // 当移动停止时停止音乐播放
        //    soundEffect.StopSound();
        //}

        // 更新 Directional Light 的旋转
        RotateDirectionalLight();
    }

    // 开始移动到下一个目标位置
    void StartMoving()
    {
        if (actionScript.GetBiochemistryPoint() <= 0)
        {
            return;
        }
        // 如果还有下一个目标位置
        if (currentDestinationIndex < autoGenerateCube.RoadPositions.Count - 1)
        {
            currentDestination = autoGenerateCube.RoadPositions[currentDestinationIndex+1];
            currentDestination.y = 1; // 将 Y 坐标设置为 1
            isMoving = true;

            // 开始移动时播放音乐
            soundEffect.PlayFootstepMusic();
        }
    }

    // 移动到目标位置
    void MoveToDestination()
    {
        // 计算移动方向和距离
        Vector3 moveDirection = (currentDestination - transform.position).normalized; // 将 Vector3 改为 UnityEngine.Vector3
        float distanceToDestination = Vector3.Distance(transform.position, currentDestination); // 将 Vector3 改为 UnityEngine.Vector3

        // 如果距离小于一个小量，则表示已经到达目标位置
        if (distanceToDestination < 0.1f)
        {
            // 更新目标位置索引，并停止移动
            currentDestinationIndex++;
            isMoving = false;
            return;
        }

        // 否则继续移动向目标位置
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    // 获取 currentDestinationIndex 的值
    public int GetCurrentDestinationIndex()
    {
        return currentDestinationIndex;
    }

    // 更新 Directional Light 的旋转
    void RotateDirectionalLight()
    {
        // 根据 currentDestinationIndex 的值来旋转 Directional Light
        float anglePerHour = -18f; // 每小时旋转的角度
        float rotationAngle = currentDestinationIndex * anglePerHour; // 根据索引计算旋转角度

        // 将 Directional Light 旋转到相应的角度
        directionalLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
    }

    public void Rest()
    {
        // 获取休息时间对应的小时数
        int restHours = actionScript.GetRestHours();

        // 计算新的目标位置索引
        int newDestinationIndex = currentDestinationIndex + restHours;

        // 如果新的目标位置索引超过了目标位置列表的范围，则将索引限制在列表末尾
        if (newDestinationIndex >= autoGenerateCube.RoadPositions.Count)
        {
            newDestinationIndex = autoGenerateCube.RoadPositions.Count - 1;
        }

        // 更新当前目标位置索引
        currentDestinationIndex = newDestinationIndex;

        // 获取新的目标位置
        Vector3 newPosition = autoGenerateCube.RoadPositions[currentDestinationIndex];

        // 将玩家移动到新的目标位置，并调整 y 坐标
        transform.position = new Vector3(newPosition.x, newPosition.y + 1f, newPosition.z);
    }


}
