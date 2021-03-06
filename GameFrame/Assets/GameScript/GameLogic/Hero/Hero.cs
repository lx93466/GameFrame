﻿using GameFrame;
using UnityEngine;
public enum AttackDirection
{
    Forward,//攻击前方
    Around//攻击四周
}

public enum AttackType
{
    None,     //没有攻击类型
    Attack,   //点击普通攻击按钮时的攻击类型, 播放攻击动画
    Attack1,  //普通动作回调第一次攻击，计算伤害
    Attack2,  //普通动作回调第二次连击，计算伤害
    Skill1,   //技能1攻击
    Skill2,   //技能2攻击
    Skill3    //技能3攻击
}

public class Hero
{
    public float m_attackDistance = 1;//攻击距离
    public int m_hp = 200;//血量
    public int m_speed = 10; //速度
    public int m_damage = 50; //攻击力	

    public int m_curHp = 200;
    public string m_name = "柔小乖";

    public Transform m_heroTransform = null;
}
