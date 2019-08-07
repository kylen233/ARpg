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

        GameRoot.Instance.LoadingWindow.SetWindowState(true);
        AsyncOperation asyncOperation= SceneManager.LoadSceneAsync(sceneName);
        callBack = () =>
        {
            float value = asyncOperation.progress;
            GameRoot.Instance.LoadingWindow.SetProgress(value);
            if (value == 1)
            {
                if (loadAction!=null)
                {
                    loadAction();
                }
                asyncOperation = null;
                callBack=null;
                GameRoot.Instance.LoadingWindow.SetWindowState(false);
            }

        };
    }

    void Update()
    {
        if (callBack!=null)
        {
            callBack();
        }
    }
}
