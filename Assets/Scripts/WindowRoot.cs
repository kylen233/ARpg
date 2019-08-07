using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour {

	protected  ResSvc resSvc=null;

    public void SetWindowState(bool isActive)
    {
        gameObject.SetActive(isActive);
        if (isActive)
        {
            Init();
        }
        else
        {
            Exit();
        }
    }

    protected virtual void Init()
    {
        resSvc = ResSvc.Instance;
    }
    protected virtual void Exit()
    {
        resSvc = null;
    }
    #region Tool Funtions

    protected void SetActive(GameObject go, bool isActive)
    {
        go.SetActive(isActive);
    }

    protected void SetActive(Transform trans, bool isActive)
    {
        trans.gameObject.SetActive(isActive);
    }

    protected void SetActive(RectTransform rectTrans, bool isActive)
    {
        rectTrans.gameObject.SetActive(isActive);
    }

    protected void SetActive(Image img, bool isActive)
    {
        img.gameObject.SetActive(isActive);
    }

    protected void SetActive(Text text, bool isActive)
    {
        text.gameObject.SetActive(isActive);
    }
    protected  void SetText(Text text, string context="")
    {
        text.text = context;
    }

    protected void SetText(Text text, int num)
    {
        SetText(text,num.ToString());
    }
    protected void SetText(Transform trans, int num)
    {
        SetText(trans.GetComponent<Text>(),num.ToString());
    }

    protected void SetText(Transform trans, string context = "")
    {
        SetText(trans.GetComponent<Text>(),context);
    }
#endregion
}
