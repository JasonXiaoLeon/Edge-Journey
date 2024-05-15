using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Deploy : MonoBehaviour
{
    [SerializeField]
    private bool isAllDone = false;
    [SerializeField]
    private GameObject deploymentUI;
    // Start is called before the first frame update

    public void Checked()
    {
        isAllDone = true;
        if (isAllDone)
        {
            deploymentUI.SetActive(false);
        }
        else
        {
            Debug.Log("not done");
        }
    }

    public bool GetIsAllDone()
    {
        return isAllDone;
    }
}
