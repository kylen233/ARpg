using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音频服务
/// </summary>
public class AudioSvc : MonoBehaviour
{
    private static AudioSvc _instance;
    public AudioSource bgAudio;
    public AudioSource uiAudio;
    public static AudioSvc Instance
    {
        get
        {
            return _instance;
        } 
    }

    public void Init()
    {
        _instance = this;
        Debug.Log("AudiocSvc Init");
    }

    public void PlayBGMusic(string name,bool isloop)
    {
        AudioClip audioClip = ResSvc.Instance.LoadAudioClip(name,true);
        if (bgAudio.clip==null||bgAudio.clip.name!=audioClip.name)
        {
            bgAudio.clip = audioClip;
            bgAudio.Play();
            bgAudio.loop = isloop;
        }
    }

    public void PlayUIMusic(string name)
    {
        AudioClip audioClip = ResSvc.Instance.LoadAudioClip(name, true);
        if (audioClip!=null)
        {
            uiAudio.PlayOneShot(audioClip);
        }

    }
}
