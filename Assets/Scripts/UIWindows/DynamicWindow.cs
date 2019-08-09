using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWindow : WindowRoot
{
    public Text textTips;
    public Animation aniText;
    private Queue<string> tipsQueue = new Queue<string>();
    private bool isShowTips;
    protected override void Init()
    {
        base.Init();
        SetActive(textTips,false);
    

    }

    public void AddTips(string tips)
    {
        lock (tips)
        {
            tipsQueue.Enqueue(tips);
        }
    }

    void Update()
    {
        if (tipsQueue.Count>0&&!isShowTips)
        {
            lock (tipsQueue)
            {
                string tips = tipsQueue.Dequeue();
                SetTips(tips);
                isShowTips = true;
            }
        }
    }
    private void SetTips(string tips)
    {
        SetText(textTips,tips);
        SetActive(textTips,true);
        aniText.Play();
        float lenght = aniText.clip.length;
        StartCoroutine(AniPlayDone(lenght, (() =>
        {
            SetActive(textTips, false);
            isShowTips = false;
        })));
    }

    private IEnumerator AniPlayDone(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        if (action!=null)
        {
            action();
        }
    }
}
