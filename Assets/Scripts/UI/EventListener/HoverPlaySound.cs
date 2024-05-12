using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPlaySound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private SoundEffect soundEffect;

    // 当鼠标指针进入UI组件时调用
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (soundEffect != null && hoverSound != null)
        {
            soundEffect.PlaySound(hoverSound);
        }
    }

    // 当鼠标指针离开UI组件时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        // 如果需要，在鼠标离开时执行一些其他操作
    }
}