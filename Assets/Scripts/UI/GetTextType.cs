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

        roadPrefabType = autoGenerateCubeScript.GetPlayerCurrentRoadPrefabType(playerTransform);
        textMeshPro.text = "Current Type: " + roadPrefabType;
    }
}
