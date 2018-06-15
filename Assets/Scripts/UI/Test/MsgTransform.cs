/*
 * 
 *   Title : "" 项目
 *
 *   Description : 传递带参数的 消息 , 只需要在接收消息的时候 把 MsgBase 里氏转换 为 MsgTransform 即可 
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

public class MsgTransform : MsgBase
{

    public string str;

    public MsgTransform(ushort msgId,string isClick)  
    {      
        this.msgId = msgId;
        this.str = isClick;
    }
	 
}
