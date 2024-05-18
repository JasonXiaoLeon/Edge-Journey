using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetTextType : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private Transform playerTransform;
    [SerializeField]
    private AutoGenerateCube autoGenerateCubeScript;
    private string roadPrefabType;
    [SerializeField]
    private bool showNextType;

    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();
        autoGenerateCubeScript = FindObjectOfType<AutoGenerateCube>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.Find("Player(Clone)").transform;
        if(!showNextType)
            ShowCurrent();  
    }

    public void ShowCurrent()
    {
        string roadPrefabType = autoGenerateCubeScript.GetPlayerRoadPrefabType(playerTransform, showNextType);
        textMeshPro.text = "Current: " + roadPrefabType;
    }

    public string GetCurrent()
    {
        return roadPrefabType = autoGenerateCubeScript.GetPlayerRoadPrefabType(playerTransform, showNextType);
    }

    public void ShowNext()
    {
        string roadPrefabType = autoGenerateCubeScript.GetPlayerRoadPrefabType(playerTransform, showNextType);
        textMeshPro.text = "Next: " + roadPrefabType;
    }

    public void SetEmptyContent()
    {
        textMeshPro.text = "";
    }
}
