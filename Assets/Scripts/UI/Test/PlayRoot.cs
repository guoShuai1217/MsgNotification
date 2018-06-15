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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRoot : UIBase
{

    private Button playBtn;
    private Button registBtn;


    private void Start()
    {
        registBtn = transform.Find("RegistBtn").GetComponent<Button>();
        playBtn = transform.Find("BeginBtn").GetComponent<Button>();

        registBtn.onClick.AddListener(OnClickRegist);
        playBtn.onClick.AddListener(OnClickPlay);

    }

    private void OnClickPlay()
    {
        MsgBase msg = new MsgBase((ushort)UIEventMsg.ClickPlay);
        Dispatch(msg);
    }

    private void OnClickRegist()
    {
        //MsgBase msg = new MsgBase((ushort)UIEventMsg.ClickRegist);
        //Dispatch(msg);

        MsgTransform msg = new MsgTransform((ushort)UIEventMsg.ClickRegist, "老铁,先注册个账号吧!");
        Dispatch(msg);

    }
}
