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
        m_executeDalegate = ExecuteMove;
    }

    void GameFixedUpdate()
    {
        if (m_agent.nextPosition == m_agent.pathEndPosition)
        {
            StopMove();
        }
    }

    void ExecuteMove(Hashtable args)
    {
        Vector3 pos = (Vector3)args["pos"];
        Move(pos);
    }
    public void Move(Vector3 pos)
    {
        if (m_agent.enabled)
        {
            m_agent.SetDestination(pos);
            m_heroTransform.LookAt(pos);
            m_heroAnimation.MoveAnimation();
        }
    }

    public void StopMove()
    {
        if (m_agent.enabled)
        {
            m_agent.Stop();
            m_agent.ResetPath();
            m_fsmControlManager.ChangeState(FSMStateIdDefine.stand);
        }
    }
}

