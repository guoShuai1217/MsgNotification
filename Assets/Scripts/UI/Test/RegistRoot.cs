/*
 * 
 *   Title : "" 项目
 *
 *   Description :
 *
 *   Author : guoShuai
 *
 *   Data : 2018
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistRoot : UIBase
{
    private Button closeBtn;

    private Text titleText;

    private void Awake()
    {
        msgIds = new ushort[]
        {
            (ushort)UIEventMsg.ClickRegist
        };

        RegistSelf(this, msgIds);
    }

    private void Start()
    {
        SetPanelActive(false);
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();
        closeBtn.onClick.AddListener(() => { SetPanelActive(false); });
        titleText = transform.Find("registBg/titleText").GetComponent<Text>();
    }


    /// <summary>
    /// 我不管谁给我发的消息 , 只要收到了我注册的消息 , 我就走对应的方法
    /// </summary>
    /// <param name="msg"></param>
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)UIEventMsg.ClickRegist:
                SetPanelActive(true);
                MsgTransform msgT = msg as MsgTransform;
                titleText.text = msgT.str;
                break;
            default:
                break;
        }
    }


    private void SetPanelActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }



}
