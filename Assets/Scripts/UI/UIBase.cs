/*
 * 
 *   Title : "" 项目
 *
 *   Description : 以 Panel 为单位 , 每个 panel 挂这个脚本
 *   
 *           作用 : 负责和其他模块或者脚本通信 ,向 UIManager 注册 mono , 还有一些 msgIds
 *           
 *                 
 *
 *   Author : guoShuai
 *
 *   Data : 2018.6.15
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBase
{
    public ushort[] msgIds;

    /// <summary>
    /// 注册消息
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="msgs"></param>
    public void RegistSelf(MonoBase mono,params ushort[] msgs)
    {
        UIManager.Instance.RegistMsg(mono, msgs);
    }

    /// <summary>
    /// 注销消息
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="msgs"></param>
    public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
    {
        UIManager.Instance.UnRegistMsg(mono, msgs);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"></param>
    public void Dispatch(MsgBase msg)
    {
        UIManager.Instance.Dispatch(msg);
        
    }


    private void OnDestroy()
    {
        if(msgIds != null)
        {
            UnRegistSelf(this,msgIds);
        }
    }

    public override void ProcessEvent(MsgBase msg)
    {
        // 这里重写没有意义 , 需要继承 UIBase 的脚本去重写
    }
}
