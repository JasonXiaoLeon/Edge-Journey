using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManage : MonoBehaviour
{
    [SerializeField]
    private Action action;

    public void ConsumeResource(string Type, int consumeAmount)
    {
        int number = 0;
        int setNumber = 0;
        action = GameObject.Find("Player(Clone)").GetComponent<Action>();
        switch (Type)
        {
            case "actionPoint":
                number = action.GetActionPoint();
                setNumber = number - consumeAmount;
                if (setNumber >= 0)
                {
                    action.SetActionPoint(setNumber);
                }
                break;
            case "widsomPoint":
                number = action.GetWidsomPoint();
                setNumber = number - consumeAmount;
                if (setNumber >= 0)
                {
                    action.SetWisdomPoint(setNumber);
                }
                break;
            case "thirtyPoint":
                number = action.GetThirtyPoint();
                setNumber = number - consumeAmount;
                if (setNumber >= 0)
                {
                    action.SetThirtyPoint(setNumber);
                }
                break;
            case "starvationPoint":
                number = action.GetStarvationPoint();
                setNumber = number - consumeAmount;
                if (setNumber >= 0)
                {
                    action.SetStarvationPoint(setNumber);
                }
                break;
            case "biochemistryPoint":
                number = action.GetBiochemistryPoint();
                setNumber = number - consumeAmount;
                if (setNumber >= 0)
                {
                    action.SetBiochemistryPoint(setNumber);
                }
                break;
            default:
                break;
        }

        if (number > 0)
        {
            var children = transform.GetComponentsInChildren<Image>();
            if (children.Length > 0)
            {
                for (int i = 0; i < consumeAmount && i < children.Length; i++)
                {
                    int lastChildIndex = children.Length - 1;
                    children[lastChildIndex].gameObject.SetActive(false);
                }
            }
        }

    }

    public void AddResource(string Type, int amount)
    {
        int number = 0;
        int newNumber = 0;

        switch (Type)
        {
            case "actionPoint":
                number = action.GetActionPoint();
                newNumber = number + amount;
                action.SetActionPoint(newNumber);
                break;
            case "widsomPoint":
                number = action.GetWidsomPoint();
                newNumber = number + amount;
                action.SetWisdomPoint(newNumber);
                break;
            case "thirtyPoint":
                number = action.GetThirtyPoint();
                newNumber = number + amount;
                action.SetThirtyPoint(newNumber);
                break;
            case "starvationPoint":
                number = action.GetStarvationPoint();
                newNumber = number + amount;
                action.SetStarvationPoint(newNumber);
                break;
            case "biochemistryPoint":
                number = action.GetBiochemistryPoint();
                newNumber = number + amount;
                action.SetBiochemistryPoint(newNumber);
                break;
            default:
                break;
        }
        // Get all inactive Images
        var children = transform.GetComponentsInChildren<Image>(true).Where(child => !child.gameObject.activeSelf).ToArray();

        // Activate a number of Images based on 'amount' and the number of inactive Images
        for (int i = 0; i < Mathf.Min(amount, children.Length); i++)
        {
            children[i].gameObject.SetActive(true);
        }
    }

    public void ShowResourceBasedOnActionPoint()
    {
        if (action == null)
        {
            return;
        }
        int actionPoint = action.GetActionPoint();

        // 获取所有的 Image 组件
        var children = transform.GetComponentsInChildren<Image>(true);

        // 根据 actionPoint 的值决定激活对应数量的 Image 组件
        for (int i = 0; i < Mathf.Min(actionPoint, children.Length); i++)
        {
            children[i].gameObject.SetActive(true);
        }

        // 将多余的 Image 组件禁用
        for (int i = actionPoint; i < children.Length; i++)
        {
            children[i].gameObject.SetActive(false);
        }
    }

}