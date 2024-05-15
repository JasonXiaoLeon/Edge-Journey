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
    [SerializeField]
    private ResourceManage apManage;


    // Start is called before the first frame update
    void Start()
    {
        clickEventListener = gameObject.GetComponent<Button>();
        apManage = GameObject.Find("行动").GetComponent<ResourceManage>();
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
        if (playerActionInstance.GetActionPoint() > 0)
        {
            int total = playerActionInstance.GetActionPoint();
            apManage.ConsumeResource("actionPoint", 1);
            playerActionInstance.SetTotalNumberIncrease(playerActionInstance.GetMoveSteps(minDiceNumber, maxDiceNumber));
            UnityEngine.Debug.Log(playerActionInstance.GetTotalNumber());

            ClickPlayMusic playMusicComponent = GetComponent<ClickPlayMusic>();
            if (playMusicComponent != null)
            {
                playMusicComponent.OnClickPlayMusic();
            }
        }
    }
}
