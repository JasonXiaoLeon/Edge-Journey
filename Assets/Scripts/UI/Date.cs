using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入 TextMeshPro 的命名空间

public class Date : MonoBehaviour
{
    [SerializeField]
    private playerController playerControllerInstance; // playerController 实例
    [SerializeField]
    private TMP_Text daysUI; // TMP_Text 组件
    [SerializeField]
    private Image hourHandImage; // 时针图像
    [SerializeField]
    private Vector2 pivotOffset; // 旋转轴相对于图片中心的偏移量
    [SerializeField]
    private int currentDay; // 旋转轴相对于图片中心的偏移量
    [SerializeField]
    private ImageChangeEvent imagechange;
    void Start()
    {
        // 获取 TMP_Text 组件
        daysUI = GameObject.Find("天数").GetComponent<TMP_Text>();
        hourHandImage = GetComponentInChildren<Image>();

        hourHandImage.rectTransform.pivot = new Vector2(pivotOffset.x / hourHandImage.rectTransform.rect.width, pivotOffset.y / hourHandImage.rectTransform.rect.height);
    }

    void Update()
    {
        playerControllerInstance = GameObject.Find("Player(Clone)").GetComponent<playerController>();
        currentDay = playerControllerInstance.GetCurrentDestinationIndex() / 24 + 1;

        // 更新显示的游戏天数
        if (daysUI != null)
        {
            daysUI.text = "Day: " + currentDay + GetDaySuffix(currentDay);
        }

        if (playerControllerInstance != null)
        {
            // 获取 currentDestinationIndex 的值
            int currentDestinationIndex = playerControllerInstance.GetCurrentDestinationIndex();

            // 计算时针旋转角度
            float hourAngle = currentDestinationIndex * -30f; // 一小时对应的旋转角度为 30 度

            // 更新时针图像的旋转角度
            hourHandImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, hourAngle);
        }
    }

    string GetDaySuffix(int day)
    {
        // 获取 day 的个位数
        int lastDigit = day % 10;

        // 如果个位数是1，则返回 "st"
        if (lastDigit == 1 && day != 11)
        {
            return "st";
        }
        // 如果个位数是2，则返回 "nd"
        else if (lastDigit == 2 && day != 12)
        {
            return "nd";
        }
        // 如果个位数是3，则返回 "rd"
        else if (lastDigit == 3 && day != 13)
        {
            return "rd";
        }
        // 其他情况返回 "th"
        else
        {
            return "th";
        }
    }

    public void ChangeByRest()
    {
        int restHours = imagechange.GetRestHours();
        if (restHours != 0)
        {
            float hourAngleChange = restHours * -30f; //
            hourHandImage.rectTransform.Rotate(0f, 0f, hourAngleChange);
            playerControllerInstance.Rest();
        }
    }

    public int getDay()
    {
        return currentDay;
    }
}

