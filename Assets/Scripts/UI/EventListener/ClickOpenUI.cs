using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOpenUI : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        UI.SetActive(true);
    }
}
