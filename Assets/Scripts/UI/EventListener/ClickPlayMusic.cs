using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlayMusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    void Start()
    {
        audioSource.clip = audioClip;
    }

    public void OnClickPlayMusic()
    {
        audioSource.Play();
    }
}
