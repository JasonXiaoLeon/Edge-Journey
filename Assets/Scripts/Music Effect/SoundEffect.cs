using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip footstepSound;
    public AudioClip foostepSoundAlt;

    // 音频播放器组件
    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // 获取音频播放器组件
        audioSource = GetComponent<AudioSource>();
        // 如果音频资源不为空，则加载音频资源
        if (footstepSound != null && foostepSoundAlt != null)
        {
            audioSource.loop = false; // 设置音乐循环播放
        }
    }

    // 播放第一个音乐
    public void PlayFootstepMusic()
    {
        // 生成随机数，决定播放哪个音乐
        int randomIndex = UnityEngine.Random.Range(0, 2);

        // 根据随机数选择音乐并播放
        AudioClip selectedClip = randomIndex == 0 ? footstepSound : foostepSoundAlt;
        if (selectedClip != null)
        {
            audioSource.clip = selectedClip;
            audioSource.Play();
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void StopSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
