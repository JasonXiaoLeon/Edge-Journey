using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Resource : MonoBehaviour
{
    [SerializeField] private Action playerActionInstance; // playerController 实例
    [SerializeField] private GameObject[] resourceContainers; // 存储资源容器的数组，每个容器包含 Image 组件
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        // 设置资源容器中的图片
        SetResourceValues();
    }

    // 更新资源值
    void Update()
    {
        // 获取 Action 实例
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
        // 如果 Action 实例为空，返回
        if (playerActionInstance == null)
            return;

        // 更新资源容器中的文本值
        UpdateResourceValues();
    }

    // 设置资源容器中的图片
    private void SetResourceValues()
    {
        // 遍历资源容器数组
        for (int i = 0; i < resourceContainers.Length; i++)
        {
            GameObject container = resourceContainers[i];

            // 获取 Image 组件
            Image image = container.GetComponentInChildren<Image>();

            // 更新 Image 组件
            if (image != null)
            {
                // 在这里设置 Image 组件的显示
            }
        }
    }

    // 更新资源容器中的图片值
    private void UpdateResourceValues()
    {
        // 遍历资源容器数组
        for (int i = 0; i < resourceContainers.Length; i++)
        {
            GameObject container = resourceContainers[i];

            // 获取 Image 组件
            Image image = container.GetComponentInChildren<Image>();
        }
    }
}