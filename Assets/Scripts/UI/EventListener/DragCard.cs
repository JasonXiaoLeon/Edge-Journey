using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    private Vector3 offset;

    void Awake()
    {
        // 获取 RectTransform 组件
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 计算鼠标点击位置与 Image 中心点的偏移
        offset = rectTransform.position - (Vector3)eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 设置 Image 的位置为鼠标当前位置加上偏移
        rectTransform.position = (Vector3)eventData.position + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖动结束时，清空偏移值
        offset = Vector3.zero;
    }
}
