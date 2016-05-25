using UnityEngine;
using System.Collections;
using GameFrame;
using System;

public class HeroMove : GameBehaviour
{
    NavMeshAgent m_agent = null;
    protected override void Init()
    {
        m_agent = Tools.GetComponent<NavMeshAgent>(gameObject);
    }
    protected override void GameFixedUpdate()
    {
        if (Input .GetMouseButtonUp(0))
        {
            Ray ray = Camera .main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics .Raycast(ray, out hit))
            {
                if (m_agent != null )
                {
                    m_agent.SetDestination(hit.point);
                    transform.LookAt(hit.point);
                    HeroLogic.m_instance.m_heroFSMManager.ChangeState(HeroStateDefine.move);
                    return;//下一帧开始计算导航想个数据
                }
            }
        }

        if (m_agent.remainingDistance < 0.001f)
        {
            m_agent.ResetPath();
            HeroLogic.m_instance.m_heroFSMManager.ChangeState(HeroStateDefine.stand);
        }
    }
}

