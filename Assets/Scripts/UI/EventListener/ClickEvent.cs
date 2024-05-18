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
    [SerializeField]
    private ActionUI actionUI;
    private bool isdone;

    // Start is called before the first frame update
    void Start()
    {
        isdone = false;
        clickEventListener = gameObject.GetComponent<Button>();
        apManage = GameObject.Find("行动").GetComponent<ResourceManage>();
        minDiceNumber = 1;
        maxDiceNumber = 3;
    }

    void Update()
    {
        playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
        if (playerActionInstance.GetActionPoint() == 0 && !isdone)
        {
            isdone = true;
            playerActionInstance.SetRecordTotalNumber();
        }
    }

    public void OnClickAttack()
    {
    }

    public void OnClickMove()
    {
        if (playerActionInstance.GetActionPoint() > 0)
        {
            int total = playerActionInstance.GetActionPoint();
            apManage.ConsumeResource("actionPoint", 1);
            playerActionInstance.SetTotalNumberIncrease(playerActionInstance.GetMoveSteps(minDiceNumber, maxDiceNumber));
            ClickPlayMusic playMusicComponent = GetComponent<ClickPlayMusic>();
            if (playMusicComponent != null)
            {
                playMusicComponent.OnClickPlayMusic();
            }
        }
    }

    public void SetIsDone(bool value)
    {
        isdone = value;
    }
}
