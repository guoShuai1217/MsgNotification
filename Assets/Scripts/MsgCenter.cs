/*
 * 
 *   Title : "" 项目
 *
 *   Description : 单例类 , 负责向各个 Manager 转发消息 (自己不处理消息,只负责转发)
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

public class MsgCenter : MonoBehaviour
{

    public static MsgCenter Instance;

    private void Awake()
    {
        Instance = this;

        // 需要向什么模块传递信息 , 就 AddComponent 哪个 Manager 脚本
        gameObject.AddComponent<UIManager>();
        

        DontDestroyOnLoad(gameObject);
    }
 
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"></param>
    public void SendToMsg(MsgBase msg)
    {
        ManagerIDEnum tempId = msg.GetManager();
        switch (tempId)
        {
            case ManagerIDEnum.UIManager:
                UIManager.Instance.ProcessEvent(msg);
                break;
            case ManagerIDEnum.GameManager:
                break;
            case ManagerIDEnum.AudioManager:
                break;
            case ManagerIDEnum.NPCManager:
                break;
            case ManagerIDEnum.CharacterManager:
                break;
            case ManagerIDEnum.NetManager:
                break;
            case ManagerIDEnum.AssetManager:
                break;
            default:
                Debug.Log("不存在该消息" + tempId);
                break;
        }
    }

    
}
