using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakeAction : MonoBehaviour
{
    [SerializeField]
    private playerController playerInstance;
    [SerializeField]
    private Action playerActionInstance;
    private GetTextType textType;
    private GetTextType currentTextType;
    private bool isPredicted = false;
    [SerializeField]
    private bool isSeeked = false;
    private ActionUI actionUI;
    private AutoGenerateCube autogenerate;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        textType = transform.Find("/游戏/Canvas/提示/预知类型").GetComponent<GetTextType>();
        currentTextType = transform.Find("/游戏/Canvas/提示/类型").GetComponent<GetTextType>();
        actionUI = GetComponent<ActionUI>();
    }


    void Update()
    {
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
        playerInstance = GameObject.Find("Player(Clone)").GetComponent<playerController>();
    }

    public void Move()
    {
        // 检查 actionPoint 是否大于 0
        if (playerActionInstance.GetBiochemistryPoint() != 0)
        {
            if (playerActionInstance.GetTotalNumber() > 0)
            {
                playerInstance.StartMoving();
                isPredicted = false;
                isSeeked = false;
                textType.SetEmptyContent();
                text.text = "";
            }
        }
    }

    public void Explore()
    {
        if (playerActionInstance.GetBiochemistryPoint() != 0)
        {
            if (playerActionInstance.GetTotalNumber() > 0)
            {
                if (!isPredicted)
                {
                    textType.ShowNext();
                    isPredicted = true;
                    actionUI.UseActionPoint(1);
                    actionUI.HandleButtonClick();
                }
            }
        }
    }

    public void SeekForSupplyAndPurchase()
    {
        float randomValue = UnityEngine.Random.value;
        if(currentTextType.GetCurrent() == "Supply")
        {
            if (playerActionInstance.GetBiochemistryPoint() != 0)
            {
                if (playerActionInstance.GetTotalNumber() > 0 && !isSeeked)
                {
                    // 40%概率获得食物
                    if (randomValue < 0.4f)
                    {
                        text.text = "Get Food! ";
                        // 处理获得食物的逻辑
                    }
                    // 20%概率获得武器
                    else if (randomValue < 0.6f)
                    {
                        text.text = "Get Weapon! ";
                        // 处理获得武器的逻辑
                    }
                    // 20%概率Empty
                    else if (randomValue < 0.8f)
                    {
                        text.text = "It is empty! ";
                        // 处理空的逻辑
                    }
                    // 20%概率获得药品
                    else
                    {
                        text.text = "Get Medicine! ";
                        // 处理获得药品的逻辑
                    }
                    actionUI.UseActionPoint(1);
                    actionUI.HandleButtonClick();
                    isSeeked = true;
                }
            }
        } else if(currentTextType.GetCurrent() == "Shop")
        {
            if (playerActionInstance.GetTotalNumber() > 0 && !isSeeked)
            {
                text.text = "purchased successfully";
                actionUI.UseActionPoint(1);
                actionUI.HandleButtonClick();
                isSeeked = true;
            }
        }
        else if (currentTextType.GetCurrent() == "Game Props")
        {
            if (playerActionInstance.GetTotalNumber() > 0 && !isSeeked)
            {
                text.text = "picked Game Props";
                actionUI.UseActionPoint(1);
                actionUI.HandleButtonClick();
                isSeeked = true;
            }
        }
    }

}
