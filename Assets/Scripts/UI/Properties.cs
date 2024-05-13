using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入 TextMeshPro 的命名空间

public class Properties : MonoBehaviour
{
    [SerializeField]
    private Action playerActionInstance; // playerController 实例
    private TMP_Text textComponent; // TMP_Text 组件

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
        // 检查 playerController 实例是否存在
        if (playerActionInstance != null)
        {
            textComponent.text = "Action: " + GetActionPoint() + "\n" +
                                 "Widsom: " + GetWidsomPoint() + "\n" +
                                 "Starvation: " + GetStarvationPoint() + "\n" +
                                 "Thirty: " + GetThirtyPoint() + "\n" +
                                 "Biochemistry: " + GetBiochemistryPoint() + "\n" +
                                 "TotalMove: " + GetTotalMove();
        }
    }

    // 获取 actionPoint 的值
    private int GetActionPoint()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetActionPoint();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }

    private int GetWidsomPoint()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetWidsomPoint();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }

    private int GetStarvationPoint()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetStarvationPoint();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }

    private int GetThirtyPoint()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetThirtyPoint();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }

    private int GetBiochemistryPoint()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetBiochemistryPoint();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }

    // 获取 actionPoint 的值
    private int GetTotalMove()
    {
        // 检查 Action 实例是否存在
        if (playerActionInstance != null)
        {
            // 返回 actionPoint 的值
            return playerActionInstance.GetTotalNumber();
        }
        else
        {
            return 0; // 如果 Action 实例不存在，返回默认值
        }
    }
}
