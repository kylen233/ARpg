using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 登录系统脚本
/// </summary>
public class LoginSys : MonoBehaviour
{
    public LoginWindow loginWindow;
    public void Init()
    {
        Debug.Log("Init LoginSys ....");
    }

    public void EnterLogin()
    {
        //TODO
        //异步加载登录场景
        ResSvc.Instance.LoadSceneAsync(Constants.SceneLogin,OpenLoginWindow);

        //并显示加载的进度

        //加载完成以后再打开注册登录界面
    }

    public void OpenLoginWindow()
    {
        loginWindow.SetWindowState(true);
    }
   
}
