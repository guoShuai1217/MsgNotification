/*
 * 
 *   Title : "" 项目
 *
 *   Description : 单例类 , 继承 ManagerBase 
 *     
 *                 作用 : 使该脚本具有发送消息的能力 
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

public class UIManager : ManagerBase
{

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private Dictionary<string, GameObject> msgDic = new Dictionary<string, GameObject>();


    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"></param>
    public void Dispatch(MsgBase msg)
    {
        // 如果消息 Id 是我 UI模块的 消息范围之内的 , 就自己处理
        if (msg.GetManager() == ManagerIDEnum.UIManager)
            ProcessEvent(msg);
        else  // 如果消息 Id 是我 UI模块的 消息范围之内的 , 就交给MsgCenter处理      
            MsgCenter.Instance.SendToMsg(msg);
    }

    /// <summary>
    /// 外部 API 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string name)
    {
        if (msgDic.ContainsKey(name))
        {
            return msgDic[name];
        }

        return null;
    }
   

    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public void RegistGameObject(string name, GameObject obj)
    {
        if (!msgDic.ContainsKey(name))
        {
            msgDic.Add(name,obj);
        }
    }

    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="name"></param>
    public void UnRegistGameObject(string name)
    {
        if (msgDic.ContainsKey(name))
            msgDic.Remove(name);
    }


}
