using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏入口
/// </summary>
public class GameRoot : MonoBehaviour
{

    public LoadingWindow LoadingWindow;
    private static GameRoot _instance;

    public static GameRoot Instance
    {
        get
        {
            return _instance;
        }
    }

    void Start () {
		Debug.Log("Game Start");
	    DontDestroyOnLoad(this.gameObject);
        _instance = this;
        Init();
	}

    private void Init()
    {
        //服务模块初始化
   
        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.Init();
        //业务系统初始化
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.Init();
        //进入登录场景并加载UI
        loginSys.EnterLogin();
    }
	
}
