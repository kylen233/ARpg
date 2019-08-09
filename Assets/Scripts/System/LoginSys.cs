using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 登录系统脚本
/// </summary>
public class LoginSys : SystemRoot
{
    public LoginWindow loginWindow;
    private static LoginSys _instance;

    public static LoginSys Instance
    {
        get
        {
            return _instance;
        }
    }

   public override void Init()
    {
        base.Init();
        _instance = this;
        Debug.Log("Init LoginSys ....");
    }

    public void EnterLogin()
    {
        //TODO
        //异步加载登录场景
        //并显示加载的进度
        resSvc.LoadSceneAsync(Constants.SceneLogin,OpenLoginWindow);
        audioSvc.PlayBGMusic(Constants.bgLogin,true);

        //加载完成以后再打开注册登录界面
    }

    public void OpenLoginWindow()
    {
        loginWindow.SetWindowState(true);
    }
   
}
