/*
 * 
 *   Title : "" 项目
 *
 *   Description : 管理基类 , 所有模块的 manager , 都要继承他
 *   
 *                 这里用的链表结构 (用Dictionary<ushort,List<MonoBase>> 也可以)
 *                 
 *                 作用 : 负责消息的 存储 和 处理
 *
 *   Author : guoShuai
 *
 *   Data : 2018.6.11
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventNode
{
    public MonoBase mono; // 当前的 MonoBehavior 类

    public EventNode next; // 指向下一个节点

    public EventNode(MonoBase tempMono)
    {
        this.mono = tempMono;
        next = null;
    }
}


public class ManagerBase : MonoBase
{
     // 存储注册的消息
    private Dictionary<ushort, EventNode> nodeDic = new Dictionary<ushort, EventNode>();


    /// <summary>
    /// 来了消息之后,通知整个消息链表 , 找到对应的 Mono 脚本去执行这个消息
    /// </summary>
    /// <param name="msg"></param>
    public override void ProcessEvent(MsgBase msg)
    {
        if (!nodeDic.ContainsKey(msg.msgId))
        {
            Debug.LogError("没有注册" + msg.msgId);
            Debug.LogError(msg.GetManager() + "这个管理器出的问题");
            return;
        }
        // 字典里有 : 从链表里找到
        EventNode tempNode = nodeDic[msg.msgId];

        do
        {
            // 通过 msg.msgId 找到对应的链表 , 全部通知
            // 链表里注册了 msg.msgId 这个消息的 mono , 都要执行这个方法
            tempNode.mono.ProcessEvent(msg);
            tempNode = tempNode.next;
        }
        while (tempNode!= null);

    }


    #region 注册消息

    /// <summary>
    /// 注册消息
    /// </summary>
    /// <param name="msg">根据 msgId 保存的</param>
    /// <param name="node">node链表</param>
    public void RegistMsg(ushort msgId , EventNode node)
    {
         // 数据链路里面没有这个 消息
        if (!nodeDic.ContainsKey(msgId))       
            nodeDic.Add(msgId, node);    
        else // 如果字典里已经有的话 , 挂到最后一个链子上
        {
             // 这个是 挂的第一个
            EventNode tempNode = nodeDic[msgId];
             // 如果不是最后一个,就一直往下找
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }

            tempNode.next = node; // 把node挂到最后一个链子上
        }
    }


    /// <summary>
    /// 注册多个消息
    /// </summary>
    /// <param name="mono">注册消息的脚本</param>
    /// <param name="msgs">注册的消息</param>
    public void RegistMsg(MonoBase mono, params ushort[] msgs)
    {
        for (int i = 0; i < msgs.Length; i++)
        {
            RegistMsg(msgs[i], new EventNode(mono));
        }
    }

    #endregion

    #region 注销消息

    /// <summary>
    /// 注销事件
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="mono"></param>
    public void UnRegistMsg(ushort msgId , MonoBase mono)
    {
        if (!nodeDic.ContainsKey(msgId))
        {
            Debug.LogError("都没有注册这个消息,你想我怎么注销?");
            return;
        }

        // 字典里有的话 :
        // 获取 挂的第一个
        EventNode tempNode = nodeDic[msgId];

        // 要注销的脚本的在头部
        if (tempNode.mono == mono)
        {
            EventNode head = tempNode;
            // 后面挂的还有
            if (head.next !=null)
            {
                //头部的指针 重新指向第二个的mono (tempNode.next 就是第二个)
                //head.mono = tempNode.next.mono; 
                //head.next = tempNode.next.next;

                nodeDic[msgId] = tempNode.next; // 指针直接指向第二个mono
                head.next = null; // 把第一个的 next 指针 置空

            }
            else // 后面挂的没有了 (就挂了一个)
            {
                nodeDic.Remove(msgId);// 直接从字典里移除掉
            }
        }
        else // 要注销的脚本在中间或者在最后
        {
            while (tempNode.next!= null && tempNode.next.mono != mono)
            {
                tempNode = tempNode.next;
            }
            // 已经找到了该节点
            if (tempNode.next.next != null) // 要注销的脚本在中间 (前一个指针的next, 直接指向下一个的下一个mono,中间的就不要了)      
            {
                //tempNode.next = tempNode.next.next;

                EventNode currentNode = tempNode.next; // 找到了当前要注销的mono
                tempNode.next = currentNode.next; // currentNode 的前一个脚本的 next 直接指向 currentNode 的后一个 mono
                currentNode.next = null; // 把 currentNode 的 next 置空
            }    
            else
            {
                tempNode.next = null; // 要注销的脚本在最后         
            }        
                 
        }
    }

    /// <summary>
    /// 注销多个事件
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="msgs"></param>
    public void UnRegistMsg(MonoBase mono,params ushort[] msgs)
    {
        for (int i = 0; i < msgs.Length; i++)
        {
            UnRegistMsg( msgs[i],mono);
        }
    }

    #endregion

}
