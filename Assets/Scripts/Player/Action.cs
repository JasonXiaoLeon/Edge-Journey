using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField]
    private int actionPoint;
    [SerializeField]
    private int widsomPoint;
    [SerializeField]
    private int starvationPoint;
    [SerializeField]
    private int thirtyPoint;
    [SerializeField]
    private int biochemistryPoint;
    [SerializeField]
    private int goldAmount;
    [SerializeField]
    private int capacityOfBag;
    [SerializeField]
    private int[] weaponList;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int diceNumber;
    [SerializeField]
    private int minDiceNumber;
    [SerializeField]
    private int maxDiceNumber;
    [SerializeField]
    private bool isRest;

    // Start is called before the first frame update
    void Start()
    {
        actionPoint = 5;
        widsomPoint = 3;
        starvationPoint = 3;
        thirtyPoint = 2;
        biochemistryPoint = 5;
        goldAmount = 20;
        capacityOfBag = 6;
        attack = 0;
        weaponList = new int[0];
        isRest = false;
    }

    // Getter 方法用于获取 actionPoint 属性的值
    public int GetActionPoint()
    {
        return actionPoint;
    }

    // 减少 actionPoint 的值
    public void DecreaseActionPoint()
    {
        if (actionPoint > 0)
        {
            actionPoint--;
        }
    }

    // Getter 方法用于获取 widsomPoint 属性的值
    public int GetWidsomPoint()
    {
        return widsomPoint;
    }

    // Getter 方法用于获取 starvationPoint 属性的值
    public int GetStarvationPoint()
    {
        return starvationPoint;
    }

    // Getter 方法用于获取 thirtyPoint 属性的值
    public int GetThirtyPoint()
    {
        return thirtyPoint;
    }

    // Getter 方法用于获取 biochemistryPoint 属性的值
    public int GetBiochemistryPoint()
    {
        return biochemistryPoint;
    }

    // Getter 方法用于获取 attack 属性的值
    public int GetGoldAmount()
    {
        return goldAmount;
    }

    // Getter 方法用于获取 attack 属性的值
    public int GetCapacityOfBag()
    {
        return capacityOfBag;
    }

    public int[] GetWeaponList()
    {
        return weaponList;
    }

    // Getter 方法用于获取 attack 属性的值
    public int GetAttack()
    {
        return attack;
    }

    private int PlayDice(int min, int max)
    {
        // 将min限制在0和6之间
        min = Mathf.Clamp(min, 0, 6);
        // 将max限制在0和6之间
        max = Mathf.Clamp(max, 0, 6);

        return UnityEngine.Random.Range(min, max + 1);
    }

    public int GetMoveSteps(int min, int max)
    {
        return PlayDice(min, max);
    }

    public int GetDamageCalculation(int min, int max)
    {
        return PlayDice(min, max) + GetAttack();
    }

    public void SetRest()
    {
        isRest = !isRest;
    }

    public bool GetRest()
    {
        return isRest;
    }
}
