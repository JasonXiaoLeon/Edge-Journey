using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    private Action playerAction;
    [SerializeField]
    private Button btnForPurchase; // 修改类型为 Button

    // Start is called before the first frame update
    void Start()
    {
        playerAction = GetComponent<Action>();
        // 获取按钮的 Button 组件
        btnForPurchase = transform.Find("/游戏/Canvas/部署阶段UI/资源/背景板/金币/金币图像").GetComponent<Button>();

        // 添加点击事件监听器
        btnForPurchase.onClick.AddListener(PurchaseGoods);
    }

    public void PurchaseGoods()
    {
        int price = 2; // 临时定义商品价格，可以根据需要从其他地方获取
        int gold = playerAction.GetGoldAmount();
        if (gold >= price)
        {
            playerAction.SetGoldAmount(gold - price);
        }
    }
}
