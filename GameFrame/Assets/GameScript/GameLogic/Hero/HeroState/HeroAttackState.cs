using GameFrame;
using System.Collections;
using UnityEngine;
public class HeroAttackState : FSMState
{
    Transform m_heroTransform = null;
    HeroAnimation m_heroAnimation = null;

    Hashtable m_attackTargets = null;

    public HeroAttackState(Transform heroTransform)
    {
        m_heroTransform = heroTransform;
        m_heroAnimation = Tools.GetComponent<HeroAnimation>(m_heroTransform.gameObject);
    }
    protected override void Init()
    {
        m_stateTime = 10000;
        m_break = true;
        m_executeDalegate = SttackStateExecute;
        m_stateId = FSMStateIdDefine.attack;
    }

    void SttackStateExecute(Hashtable args)
    {
        m_attackTargets = args;
        m_heroAnimation.AttackAnimation(AttackType.Attack1);
    }
    protected override void EndOfExecute()
    {
        //计算伤害
        foreach (var target in m_attackTargets)
        {
            FSMManager enermyFSMManager = target as FSMManager;
            if (enermyFSMManager != null)
            {
                                
            }
        }
    }
}