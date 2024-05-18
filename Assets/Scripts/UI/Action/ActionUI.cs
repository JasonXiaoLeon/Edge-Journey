using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUI : MonoBehaviour
{
    [SerializeField]
    private bool isDeployed = false;
    [SerializeField]
    private Deploy deployComponent;
    [SerializeField]
    private Action actionComponent;
    [SerializeField]
    private Deploy deploy;
    // Add a list to store clicked button names
    [SerializeField]
    private List<string> clickedButtons = new List<string>();

    // Method to handle button click
    public void HandleButtonClick()
    {
        if (actionComponent.GetTotalNumber() >= 0 && actionComponent.GetActionPoint() == 0)
        {
            // Get the name of the game object to which the button belongs
            string gameObjectName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.gameObject.name;
            // Record the clicked button name
            if (actionComponent.GetTotalNumber() > 0)
            {
                clickedButtons.Add(gameObjectName);
                actionComponent.SetMoveAmount(GetForwardCount());
            }
            // Handle other logic here if needed
        }
        else if (actionComponent.GetTotalNumber() == 0 && actionComponent.GetActionPoint() == 0)
        {
            ChangeDeployButton();
        }
    }

    void Update()
    {
        actionComponent = GameObject.Find("Player(Clone)").GetComponent<Action>();
        isDeployed = deployComponent.GetIsAllDone();
    }

    public void UseActionPoint(int value)
    {
        int totalMove = actionComponent.GetTotalNumber();
        if (ValidationForAP(value, totalMove) && actionComponent.GetActionPoint() == 0)
            actionComponent.SetTotalNumberDecrease(value);
    }

    public bool ValidationForAP(int value, int totalap)
    {
        if ((totalap - value) >= 0)
            return true;
        else
            return false;
    }

    public List<string> GetClickedButtons()
    {
        return clickedButtons;
    }

    public void ChangeDeployButton()
    {
        deploy.SetIsAllDone();
    }

    public int GetForwardCount()
    {
        int forwardCount = 0;

        // Loop through clickedButtons list
        foreach (string buttonName in clickedButtons)
        {
            // Check if the button name contains "forward"
            if (buttonName.ToLower().Contains("forward"))
            {
                forwardCount++; // Increment forwardCount if "forward" is found
            }
        }

        return forwardCount; // Return the total count of "forward"
    }
}
