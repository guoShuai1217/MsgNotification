/*
 * 
 *   Title : "" 项目
 *
 *   Description : 消息中心基类 , 主要是跟据传进来的 msgId 来判断属于哪个 mananger 模块的
 *   
 *                 如果想传参数的话 , 另写一个脚本继承 MsgBase 即可 (如 MsgTransform 脚本) ;      
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

public class MsgBase
{
    // 最多 65535 个消息
    public ushort msgId;

    public MsgBase()
    {
        msgId = 0;
    }
       
     // 构造
    public MsgBase(ushort msgId)
    {
        this.msgId = msgId;
    }
	 
    /// <summary>
    /// 获取消息ID
    /// </summary>
    /// <returns></returns>
    public ManagerIDEnum GetManager()
    {
        // 3003 / 3000 = 1 ,  1 * 3000 = 3000 ,   这个消息属于 是 GameManager 的
        int tempId = msgId / FrameTools.msgSpan;
        return (ManagerIDEnum)(tempId * FrameTools.msgSpan);
    }	 
}
