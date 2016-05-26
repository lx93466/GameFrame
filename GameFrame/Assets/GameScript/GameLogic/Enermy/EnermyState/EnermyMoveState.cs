using GameFrame;
using System.Collections;
using UnityEngine;

public class EnermyMoveState : FSMState
{
    Transform m_enermyTransform = null;
    EnermyAnimation m_enermyAnimation = null;
    Vector3 m_targetPos;
    NavMeshAgent m_agent = null;
    public EnermyMoveState(Transform enermyTransform)
    {
        m_enermyTransform = enermyTransform;
        m_enermyAnimation = Tools.GetComponent<EnermyAnimation>(m_enermyTransform.gameObject);
        m_agent = Tools.GetComponent<NavMeshAgent>(m_enermyTransform.gameObject);
    }
    protected override void Init()
    {
        m_stateTime = 10000;
        m_break = true;
        m_executeDalegate = MoveStateExecute;
        m_stateId = FSMStateIdDefine.move;
    }

    void MoveStateExecute(Hashtable args)
    {
        Transform heroTransform = args["heroTransform"] as Transform;
        if (heroTransform != null)
        {
            if (m_fsmControlManager.m_curState != this || m_targetPos != heroTransform.position)
            {
                m_targetPos = heroTransform.position;
                m_enermyTransform.LookAt(m_targetPos);
                m_agent.SetDestination(heroTransform.position);
                m_enermyAnimation.MoveAnimation();
            }
        }

        if (m_agent.nextPosition == m_agent.pathEndPosition)
        {
            m_agent.ResetPath();
            HeroLogic.m_instance.m_heroFSMManager.ChangeState(FSMStateIdDefine.stand);
        }
    }
}

