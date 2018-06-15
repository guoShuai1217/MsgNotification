/*
 * 
 *   Title : "" 项目
 *
 *   Description : 这个框架的工具类 ,封装一些工具
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

/// <summary>
/// 游戏的几大模块(枚举)
/// </summary>
public enum ManagerIDEnum
{
    UIManager = 0,

    GameManager = FrameTools.msgSpan,

    AudioManager = FrameTools.msgSpan *2,

    NPCManager = FrameTools.msgSpan * 3,

    CharacterManager = FrameTools.msgSpan * 4,

    NetManager = FrameTools.msgSpan * 5,

    AssetManager = FrameTools.msgSpan * 6
}

public class FrameTools  
{

    public const int msgSpan = 3000;
	 
}
