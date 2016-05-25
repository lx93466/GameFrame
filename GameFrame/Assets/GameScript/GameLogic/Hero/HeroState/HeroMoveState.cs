using GameFrame;
using UnityEngine;
public class HeroMoveState : FSMState
{
    Transform m_heroTransform = null;
    HeroAnimation m_heroAnimation = null;
    NavMeshAgent m_agent = null;
   
    public HeroMoveState(Transform heroTransform)
    {
        m_heroTransform = heroTransform;
        m_heroAnimation = Tools.GetComponent<HeroAnimation>(m_heroTransform.gameObject);
        m_agent = Tools.GetComponent<NavMeshAgent>(m_heroTransform.gameObject);
    }
    protected override void Init()
    {
        m_stateTime = 10000;
        m_break = true;
        m_executeDalegate = MoveStateExecute;
        m_stateId = HeroStateDefine.move;
    }

    void MoveStateExecute()
    {
        m_heroAnimation.MoveAnimation();
    }
}

