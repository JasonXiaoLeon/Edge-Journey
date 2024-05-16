using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeEvent : MonoBehaviour
{
    public Sprite[] images; // 存储要切换的图片数组
    private int currentIndex = 0; // 当前显示的图片索引
    private Image imageComponent; // 图片组件的引用
    private Action playerActionInstance; // playerController 实例
    [SerializeField]
    private AudioClip coinFlip;
    [SerializeField]
    private SoundEffect soundEffect; // 添加声音效果组件
    [SerializeField]
    private ClickEvent clickEvent;
    [SerializeField]
    private ActionUI actionUI;
    private int leftValue;

    // 在 Start 方法中获取 Image 组件的引用
    void Start()
    {
        imageComponent = GetComponent<Image>();
        if (images.Length > 0)
        {
            imageComponent.sprite = images[currentIndex]; // 显示第一张图片
        }
    }

    void Update()
    {
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
    }

    // 当按钮被点击时调用的方法，切换图片
    public void ChangeImage()
    {
        // 检查图片数组是否为空
        if (images.Length == 0)
        {
            return;
        }
        if (playerActionInstance.GetRecordTotalNumber() != 0)
        {
            // 更新索引，循环显示图片
            currentIndex = (currentIndex + 1) % images.Length;
            // 更新显示的图片
            imageComponent.sprite = images[currentIndex];
            soundEffect.PlaySound(coinFlip);
        }
    }

    public void TakeARest()
    {
        if (playerActionInstance.GetRecordTotalNumber() != 0)
        {
            playerActionInstance.SetRest();
            leftValue = playerActionInstance.RecoverActionPoint();
            playerActionInstance.SetActionPoint(leftValue);
            playerActionInstance.ClearTotalNumber(0);
            playerActionInstance.SetRecoverActionPoint();
            playerActionInstance.SetMoveAmount(0);
            clickEvent.SetIsDone(false);
            actionUI.GetClickedButtons().Clear();
        }
    }

    public int GetRestHours()
    {
        return playerActionInstance.GetRestHours();
    }
}
