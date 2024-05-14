using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CardSliderEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    public RectTransform targetTransform;
    public Vector2 slideInPosition;
    public Vector2 slideOutPosition;
    public float slideSpeed = 5f;
    public float returnSpeed = 10f; // 添加一个返回速度参数

    private bool isMouseOver = false;
    private bool isDragging = false; // 新增一个标志来表示是否正在拖动

    private Vector2 originalPosition;

    private void Start()
    {
        // 保存原始位置
        originalPosition = targetTransform.anchoredPosition;
    }

    private void Update()
    {
        if(!isDragging) // 如果没有拖动，则进行插值运算
        {
            Vector2 targetPosition = isMouseOver ? slideInPosition : slideOutPosition;
            // 使用 Vector2.Lerp 进行平滑移动
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 当拖动时，取消悬停效果并停止自动滑动
        isMouseOver = false;
        isDragging = true; // 标记为正在拖动

        // 设置目标位置为当前鼠标位置
        RectTransformUtility.ScreenPointToLocalPointInRectangle(targetTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        targetTransform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖动结束后，恢复悬停效果
        isDragging = false;
        StartCoroutine(MoveToOriginalPosition());
        isMouseOver = true;
    }

    private IEnumerator MoveToOriginalPosition()
    {
        while (Vector2.Distance(targetTransform.anchoredPosition, originalPosition) > 0.01f)
        {
            // 使用 Vector2.Lerp 进行平滑移动
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, originalPosition, returnSpeed * Time.deltaTime);
            yield return null;
        }

        // 确保最终位置准确
        targetTransform.anchoredPosition = originalPosition;
    }
}
