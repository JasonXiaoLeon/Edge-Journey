using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    [SerializeField]
    private Button clickEventListener;
    [SerializeField]
    private Action playerActionInstance; // playerController 实例
    [SerializeField]
    private int minDiceNumber;
    [SerializeField]
    private int maxDiceNumber;

    // Start is called before the first frame update
    void Start()
    {
        clickEventListener = gameObject.GetComponent<Button>();

        minDiceNumber = 1;
        maxDiceNumber = 3;
    }

    void Update()
    {
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();

    }

    public void OnClickAttack()
    {
        UnityEngine.Debug.Log(playerActionInstance.GetDamageCalculation(minDiceNumber, maxDiceNumber));
    }

    public void OnClickMove()
    {
        UnityEngine.Debug.Log(playerActionInstance.GetMoveSteps(minDiceNumber, maxDiceNumber));
    }
}
