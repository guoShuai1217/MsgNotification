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

public class StartRoot : UIBase
{
    private Button closeBtn;

    private void Awake()
    {

        // 注册我感兴趣的消息 
        msgIds = new ushort[]
        {
           (ushort)UIEventMsg.ClickPlay
        };
      
        RegistSelf(this, msgIds);
    }

    private void Start()
    {
        SetPanelActive(false);
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();
        closeBtn.onClick.AddListener(() => { SetPanelActive(false); });
    }


    /// <summary>
    /// 我不管谁给我发的消息 , 只要收到了我注册的消息 , 我就走对应的方法
    /// </summary>
    /// <param name="msg"></param>
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)UIEventMsg.ClickPlay:
                SetPanelActive(true);
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
