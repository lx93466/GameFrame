using GameFrame;
using UnityEngine;
using System.Collections;
public class HeroStandState : FSMState
{
    Transform m_heroTransform = null;
    HeroAnimation m_heroAnimation = null;
    public HeroStandState(Transform heroTransform)
    {
        m_heroTransform = heroTransform;
        m_heroAnimation = Tools.GetComponent<HeroAnimation>(m_heroTransform.gameObject);
    }
    protected override void Init()
    {
        m_stateTime = 10000;
        m_break = true;
        m_executeDalegate = MoveStateExecute;
        m_stateId = FSMStateIdDefine.stand;
    }

    void MoveStateExecute(Hashtable args)
    {
        m_heroAnimation.StandAnimation();
    }
}

