using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏入口
/// </summary>
public class GameRoot : MonoBehaviour
{

    public LoadingWindow loadingWindow;
    public DynamicWindow dynamicWindow;
    private static GameRoot _instance;

    public static GameRoot Instance
    {
        get
        {
            return _instance;
        }
    }

    void Start () {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Game Start");
	    ClearUI();
        Init();
	}

    void ClearUI()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWindow.SetWindowState(true);
    }
    private void Init()
    {
        //服务模块初始化
        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.Init();
        AudioSvc audioSvc = GetComponent<AudioSvc>();
        audioSvc.Init();
        //业务系统初始化
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.Init();
        //进入登录场景并加载UI
        loginSys.EnterLogin();
    }

    public static void AddTips(string tips)
    {
        Instance.dynamicWindow.AddTips(tips);
    
    }
}
