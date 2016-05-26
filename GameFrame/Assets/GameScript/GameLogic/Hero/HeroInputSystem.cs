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
    protected override void Init()
    {
        m_instance = this;
        RunFixedUpdate();
    }
    protected override void GameFixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                m_curSignal = HeroInputSignal.Move;
                Hashtable args = new Hashtable();
                args["pos"] = hit.point;
                HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.move, args);
                return;
            }
        }
        switch (m_curSignal)
        {
            case HeroInputSignal.Attack1:
                break;
            case HeroInputSignal.Attack2:
                break;
            case HeroInputSignal.Skill1:
                break;
            case HeroInputSignal.Skill2:
                break;
            case HeroInputSignal.Skill3:
                break;
            default:
                break;
        }
       
    }
}

