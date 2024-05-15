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

    // Add a list to store clicked button names
    [SerializeField]
    private List<string> clickedButtons = new List<string>();

    // Method to handle button click
    public void HandleButtonClick()
    {
        if (actionComponent.GetTotalNumber() > 0)
        {
            // Get the name of the game object to which the button belongs
            string gameObjectName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.gameObject.name;
            // Record the clicked button name
            clickedButtons.Add(gameObjectName);
            Debug.Log(clickedButtons);
            // Handle other logic here if needed
        }
    }

    void Update()
    {
        actionComponent = GameObject.Find("Player(Clone)").GetComponent<Action>();
        isDeployed = deployComponent.GetIsAllDone();
    }

    public void UseActionPoint(int value)
    {
        int totalap = actionComponent.GetTotalNumber();
        if(ValidationForAP(value, totalap))
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
}
