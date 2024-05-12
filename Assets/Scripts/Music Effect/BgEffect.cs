using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgEffect : MonoBehaviour
{
    // 音频资源
    public AudioClip morningMusic;
    public AudioClip nightMusic;
    public AudioClip Rooster;

    // 音频播放器组件
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private playerController playerControllerInstance; // playerController 实例

    // Start is called before the first frame update
    void Start()
    {
        // 获取音频播放器组件
        audioSource = GetComponent<AudioSource>();

        // 如果音频资源不为空，则加载音频资源
        if (morningMusic != null && nightMusic != null)
        {
            audioSource.clip = nightMusic; // 设置默认音乐为第一个音乐
            audioSource.loop = true; // 设置音乐循环播放
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerControllerInstance = GameObject.Find("Player(Clone)").GetComponent<playerController>();

        if (playerControllerInstance != null)
        {
            // 使用取余操作符确保 currentDestinationIndex 在 0 到 23 的范围内
            int currentDestinationIndex = playerControllerInstance.GetCurrentDestinationIndex() % 24;

            // 在这里根据currentDestinationIndex值执行你的逻辑
            if (currentDestinationIndex > 9 && currentDestinationIndex <= 18)
            {
                // 播放第一个音乐
                if (audioSource.clip != morningMusic)
                {
                    audioSource.clip = morningMusic;
                    audioSource.Play();
                }
            }
            else if (currentDestinationIndex == 9)
            {
                // 播放第一个音乐
                if (audioSource.clip != Rooster)
                {
                    audioSource.clip = Rooster;
                    audioSource.Play();
                }
            }
            else if (currentDestinationIndex >= 19 || currentDestinationIndex <= 8)
            {
                // 播放第二个音乐
                if (audioSource.clip != nightMusic)
                {
                    audioSource.clip = nightMusic;
                    audioSource.Play();
                }
            }
        }

    }
}
