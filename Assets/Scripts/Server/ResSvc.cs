using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 资源加载脚本
/// </summary>
public class ResSvc : MonoBehaviour
{

    private static ResSvc _instance;

    public static ResSvc Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Init()
    {
        Debug.Log("Init ResSvc....");
        _instance = this;
        //加载资源
    }

    private Action callBack;
   public void LoadSceneAsync(string sceneName,Action loadAction)
    {

        GameRoot.Instance.loadingWindow.SetWindowState(true);
        AsyncOperation asyncOperation= SceneManager.LoadSceneAsync(sceneName);
        callBack = () =>
        {
            float value = asyncOperation.progress;
            GameRoot.Instance.loadingWindow.SetProgress(value);
            if (value == 1)
            {
                if (loadAction!=null)
                {
                    loadAction();
                }
                asyncOperation = null;
                callBack=null;
                GameRoot.Instance.loadingWindow.SetWindowState(false);
            }

        };
    }
    private Dictionary<string,AudioClip> audioClipDic=new Dictionary<string, AudioClip>();
    public AudioClip LoadAudioClip(string name, bool isCache)
    {
        AudioClip audioClip = null;
        string loadPath = "AudioClip/" + name;
        if (!audioClipDic.TryGetValue(loadPath,out audioClip))
        {
            audioClip = Resources.Load<AudioClip>(loadPath);
            if (audioClip==null)
            {
                Debug.Log("找不到对应的音频文件"+loadPath);
                return null;
            }
            if (isCache)
            {
               audioClipDic.Add(loadPath,audioClip);
            }
        }
        return audioClip;

    }
    void Update()
    {
        if (callBack!=null)
        {
            callBack();
        }
    }
}
