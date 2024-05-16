using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetTextList : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    [SerializeField]
    private AutoGenerateCube autoGenerateCubeScript;
    private string allTypeAmount;


    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = autoGenerateCubeScript.GetAllTypeAmount();
    }
}
