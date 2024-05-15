using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowActionList : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component
    private TextMeshProUGUI textMeshProComponent;

    // Reference to the ActionUI script
    public ActionUI actionUIScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        textMeshProComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ActionUI script reference is not null
        if (actionUIScript != null)
        {
            // Get the clicked buttons list from the ActionUI script using the GetClickedButtons method
            List<string> clickedButtons = actionUIScript.GetClickedButtons();

            // Check if the list is not null and contains elements
            if (clickedButtons != null && clickedButtons.Count > 0)
            {
                // Create a string to store the clicked buttons names
                string clickedButtonsText = "Clicked Sequence:\n";

                // Iterate through the list and append each button name to the string
                foreach (string buttonName in clickedButtons)
                {
                    clickedButtonsText += buttonName + "\n";
                }

                // Update the TextMeshProUGUI component with the clicked buttons information
                textMeshProComponent.text = clickedButtonsText;
            }
            else
            {
                // If the list is empty, display a default message
                textMeshProComponent.text = "";
            }
        }
    }
}
