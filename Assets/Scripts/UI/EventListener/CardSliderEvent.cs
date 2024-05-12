using UnityEngine;
using UnityEngine.EventSystems;

public class CardSliderEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform targetTransform;
    public Vector2 slideInPosition;
    public Vector2 slideOutPosition;
    public float slideSpeed = 5f;

    private bool isMouseOver = false;

    private void Update()
    {
        if (isMouseOver)
        {
            // 如果鼠标悬停在图像上，则向滑入位置移动
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, slideInPosition, slideSpeed * Time.deltaTime);
        }
        else
        {
            // 如果鼠标不在图像上，则向滑出位置移动
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, slideOutPosition, slideSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 当鼠标进入时，将 isMouseOver 设置为 true
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 当鼠标离开时，将 isMouseOver 设置为 false
        isMouseOver = false;
    }
}
