/*
 * 
 *   Title : "" 项目
 *
 *   Description : 用于扩展 MonoBehavior 类
 *   
 *    框架注意事项 : 
 *                  
 *               1. 框架先初始化 
 *               
 *               2. Manager 要初始化完成 
 *               
 *               3. UIBase 才能进行初始化
 *                  
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

public abstract  class MonoBase : MonoBehaviour
{
    /// <summary>
    /// 处理消息
    /// </summary>
    /// <param name="temMsg">消息</param>
    public abstract void ProcessEvent(MsgBase msg);
	 
}
