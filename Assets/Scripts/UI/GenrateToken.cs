using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenrateToken : MonoBehaviour
{
    [SerializeField]
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
            GenerateImages(playerActionInstance.GetBiochemistryPoint() - 1, biochemistryPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetStarvationPoint() - 1, starvationPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetThirtyPoint() - 1, thirtyPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetWidsomPoint() - 1, widsomPointPrefab.rectTransform);
            GenerateImages(playerActionInstance.GetActionPoint() - 1, actionPointPrefab.rectTransform);
            isGenerated = true;
        }    
    }

    public void GenerateImages(int count, RectTransform parentTransform)
    {
        float initialX = parentTransform.localPosition.x + offsetX;

        // 获取 Image 组件
        Image originalImage = parentTransform.GetComponent<Image>();

        for (int i = 0; i < count; i++)
        {
            // 实例化新的 Image 组件
            Image newImage = new GameObject("Image", typeof(Image)).GetComponent<Image>();
            // 将新的 Image 设置为 parentTransform 的子对象
            newImage.transform.SetParent(parentTransform);
            // 设置新生成的 Image 的位置
            newImage.rectTransform.localPosition = new Vector3(initialX + i * offsetX, 0f, 0f);
            // 将原始 Image 组件的属性复制到新的 Image 上
            newImage.sprite = originalImage.sprite;
            newImage.color = originalImage.color;
            newImage.material = originalImage.material;
            newImage.raycastTarget = originalImage.raycastTarget;
        }
    }
}