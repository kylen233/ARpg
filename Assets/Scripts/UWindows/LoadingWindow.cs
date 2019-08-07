using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 加载窗口脚本
/// </summary>
public class LoadingWindow : WindowRoot
{

    public Text textTips;
    public Image imaFront;
    public Image imaPoint;
    public Text textPercentage;
    private float fgWidth;
  protected override void Init()
  {
      base.Init();
      fgWidth = imaFront.GetComponent<RectTransform>().sizeDelta.x;
      SetText(textTips, " 这是一条提示");
      SetText(textPercentage, "0%");
        imaFront.fillAmount = 0;
      imaPoint.transform.localPosition = new Vector3(-490, 0, 0);
  }

    public void SetProgress(float prg)
    {
        imaFront.fillAmount = prg;
        SetText(textPercentage, (int) (prg * 100)+ "%");
        imaPoint.transform.localPosition = new Vector3(prg * fgWidth - 490, 0, 0);
    }
}
