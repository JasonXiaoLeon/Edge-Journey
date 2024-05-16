using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Properties : MonoBehaviour
{
    [SerializeField]
    private Action playerActionInstance;
    private TMP_Text textComponent;

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
                                 "TotalMove: " + GetTotalMove() + "\n" +
                                  "TotalMove(U): " + GetRecordTotalNumber() + "\n" +
                                  "Rest(Hours): " + GetRestHours() + "\n" +
                                  "Forward: " + GetForward();
        }
    }

    // Getter methods
    private int GetActionPoint()
    {
        return playerActionInstance != null ? playerActionInstance.GetActionPoint() : 0;
    }

    private int GetWidsomPoint()
    {
        return playerActionInstance != null ? playerActionInstance.GetWidsomPoint() : 0;
    }

    private int GetStarvationPoint()
    {
        return playerActionInstance != null ? playerActionInstance.GetStarvationPoint() : 0;
    }

    private int GetThirtyPoint()
    {
        return playerActionInstance != null ? playerActionInstance.GetThirtyPoint() : 0;
    }

    private int GetBiochemistryPoint()
    {
        return playerActionInstance != null ? playerActionInstance.GetBiochemistryPoint() : 0;
    }

    private int GetTotalMove()
    {
        return playerActionInstance != null ? playerActionInstance.GetTotalNumber() : 0;
    }

    private int GetRecordTotalNumber()
    {
        return playerActionInstance != null ? playerActionInstance.GetRecordTotalNumber() : 0;
    }

    private int GetRestHours()
    {
        return playerActionInstance != null ? playerActionInstance.RecoverActionPoint() : 0;
    }

    private int GetForward()
    {
        return playerActionInstance != null ? playerActionInstance.GetMoveAmount() : 0;
    }
}
