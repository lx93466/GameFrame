using UnityEngine;
using System.Collections;
using GameFrame;
using System;

public enum HeroInputSignal
{
    None,
    Move,
    Attack1,
    Attack2,
    Skill1,
    Skill2,
    Skill3
}

public class HeroInputSystem : GameBehaviour
{
    public static HeroInputSystem m_instance = null;
    public HeroInputSignal m_curSignal = HeroInputSignal.None;
    Hashtable m_args = new Hashtable();
    protected override void Init()
    {
        m_instance = this;
        RunFixedUpdate();
    }
    protected override void GameFixedUpdate()
    {
        m_args.Clear();
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                m_curSignal = HeroInputSignal.Move;
                m_args["pos"] = hit.point;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.move, m_args);
                return;
            }
        }
        switch (m_curSignal)
        {
            case HeroInputSignal.Attack1:
                m_args["attackType"] = AttackType.Attack1;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.attack, m_args);
                break;
            case HeroInputSignal.Attack2:
                m_args["attackType"] = AttackType.Attack2;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.attack, m_args);
                break;
            case HeroInputSignal.Skill1:
                m_args["attackType"] = AttackType.Skill1;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.attack, m_args);
                break;
            case HeroInputSignal.Skill2:
                m_args["attackType"] = AttackType.Skill2;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.attack, m_args);
                break;
            case HeroInputSignal.Skill3:
                m_args["attackType"] = AttackType.Skill3;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.attack, m_args);
                break;
            default:
                break;
        }
    }
}

