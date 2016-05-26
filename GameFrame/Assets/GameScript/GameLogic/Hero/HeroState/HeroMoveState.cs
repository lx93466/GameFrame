using GameFrame;
using System.Collections;
using UnityEngine;

public class HeroMoveState : FSMState
{
    Transform m_heroTransform = null;
    HeroAnimation m_heroAnimation = null;
    NavMeshAgent m_agent = null;
    public HeroMoveState(Transform heroTransform)
    {
        m_stateTime = 10000;
        m_break = true;
        m_stateId = FSMStateIdDefine.move;

        m_heroTransform = heroTransform;
        m_heroAnimation = Tools.GetComponent<HeroAnimation>(m_heroTransform.gameObject);
        m_agent = Tools.GetComponent<NavMeshAgent>(heroTransform.gameObject);
        m_fixedUpdateDalegate = GameFixedUpdate;
    }

    void GameFixedUpdate()
    {
        if (m_agent.nextPosition == m_agent.pathEndPosition)
        {
            StopMove();
            m_agent.ResetPath();
        }
    }

    public void Move(Vector3 pos)
    {
        m_agent.SetDestination(pos);
        m_heroTransform.LookAt(pos);
        m_heroAnimation.MoveAnimation();
    }

    public void StopMove()
    {
        m_agent.Stop();
        m_agent.ResetPath();
        m_fsmControlManager.ChangeState(FSMStateIdDefine.stand);
    }
}

