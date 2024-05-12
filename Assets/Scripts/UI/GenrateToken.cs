using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenrateToken : MonoBehaviour
{
    private Action playerActionInstance; // playerController 实例
    private bool isGenerated = false;
    [SerializeField] private Image biochemistryPointPrefab;
    [SerializeField] private Image starvationPointPrefab;
    [SerializeField] private Image thirtyPointPrefab;
    [SerializeField] private Image widsomPointPrefab;
    [SerializeField] private Image actionPointPrefab;

    private float offsetX = 100f;

    // Update is called once per frame
    void Update()
    {
        if (!isGenerated)
        {
            playerActionInstance = GameObject.Find("Player(Clone)").GetComponent<Action>();
            GenerateImages(playerActionInstance.GetBiochemistryPoint(), biochemistryPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetStarvationPoint(), starvationPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetThirtyPoint(), thirtyPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetWidsomPoint(), widsomPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetActionPoint(), actionPointPrefab.rectTransform);
            isGenerated = true;
        }    
    }

    public void GenerateImages(int count, RectTransform parentTransform)
    {
        float initialX = parentTransform.localPosition.x;
        for (int i = 0; i < count; i++)
        {
            // 实例化 Image 组件
            Image newImage = Instantiate(parentTransform.GetComponent<Image>(), parentTransform);
            // 设置新生成的 Image 的位置
            newImage.rectTransform.localPosition = new Vector3(initialX + i * offsetX, 0f, 0f);
        }
    }
}
