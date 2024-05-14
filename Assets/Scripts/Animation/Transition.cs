using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // 目标位置
    [SerializeField]
    private Transform targetPosition;
    // 含有 Animator 组件的位置
    [SerializeField]
    private Transform animatorPosition;
    // 动画控制器
    private Animator animator;

    void Start()
    {
        // 将 targetPosition 设置为父物体的 transform
        if (transform.parent != null)
        {
            targetPosition = transform.parent.transform;
        }
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
        animatorPosition = transform;
    }

    public void PlayMoveAnimation(float transitionDuration)
    {
        // 计算从当前位置到目标位置的向量
        Vector3 targetDirection = targetPosition.position - animatorPosition.position;

        // 将向量转换为旋转角度
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // 将角度设置到 Animator 控制器中
        animator.SetFloat("DirectionX", targetRotation.x);
        animator.SetFloat("DirectionY", targetRotation.y);

        // 设置过渡持续时间
        animator.SetFloat("TransitionDuration", transitionDuration);

        // 播放移动动画
        animator.SetTrigger("Move");
    }
}
