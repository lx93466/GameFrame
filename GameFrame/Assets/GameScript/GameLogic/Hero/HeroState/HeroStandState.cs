using GameFrame;
using UnityEngine;
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
        m_stateId = HeroStateDefine.stand;
    }

    void MoveStateExecute()
    {
        m_heroAnimation.StandAnimation();
    }
}

