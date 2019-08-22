using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
/// <summary>
/// 登录窗口脚本
/// </summary>
public class LoginWindow : WindowRoot
{
    public Button btn_notice;
    public Button btn_Enter;
    public InputField inputField_account;
    public InputField inputField_password;

    protected override void Init()
    {
        base.Init();
        //更新本地存储的账号密码
        if (PlayerPrefs.HasKey("Account")&&PlayerPrefs.HasKey("Password"))
        {
            inputField_account.text = PlayerPrefs.GetString("Account");
            inputField_password.text = PlayerPrefs.GetString("Password");
        }
        else
        {
            inputField_account.text = "";
            inputField_password.text = "";
        }
    }

    public void ClickEnterBtn()
    {
        string Account = inputField_account.text;
        string Password = inputField_password.text;
        audioSvc.PlayUIMusic(Constants.UILoginBtn);
        if (Account!=""&&Password!="")
        {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Account",Account);
            PlayerPrefs.SetString("Password",Password);
        }
        //发送网络消息

        //ToRemove
        LoginSys.Instance.RepLogin();
    }

    public void ClickNoticeBtn()
    {
        audioSvc.PlayUIMusic(Constants.UIClickBtn);
        GameRoot.AddTips("功能正在开发中");
    }
    
}
