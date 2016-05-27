using GameFrame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeroAttackState : FSMState
{
    Transform m_heroTransform = null;
    HeroAnimation m_heroAnimation = null;

    HashSet<FSMManager> m_attackTargets = null;

    public AttackType m_attackType = AttackType.None;
    public HeroAttackState(Transform heroTransform)
    {
        m_heroTransform = heroTransform;
        m_heroAnimation = Tools.GetComponent<HeroAnimation>(m_heroTransform.gameObject);
    }
    protected override void Init()
    {
        m_stateTime = 0.5f;
        m_break = true;
        m_executeDalegate = SttackStateExecute;
        m_stateId = FSMStateIdDefine.attack;
    }


    void SttackStateExecute(Hashtable args)
    {
        m_attackTargets = args["enermyFSMManagers"] as HashSet<FSMManager>;
        m_attackType = (AttackType)args["attackType"];
        if (m_attackTargets == null || m_attackTargets.Count <= 0)
        {
            m_attackTargets = BattleController.m_battleController.HeroGetAttackableEnermies();
        }
        m_heroAnimation.AttackAnimation(m_attackType);
    }

    public override void PreChangeToNextState()
    {
        HeroAttackState nextAttackState = m_nextState as HeroAttackState;
        //如果当前是Attack攻击类型，则他可以被Attack攻击类型打断，此为连击效果，Attack攻击类型由点击普通攻击按钮触发
        if (nextAttackState != null && m_attackType == AttackType.Attack && nextAttackState.m_attackType == AttackType.Attack)
        {
            m_break = true;
        }
    }
    protected override void EndOfExecute()
    {
        //重置被打断状态
        m_break = false;
        if (m_attackType == AttackType.Attack1 || m_attackType == AttackType.Attack2)
        {
            //计算伤害
            foreach (var target in m_attackTargets)
            {
                FSMManager enermyFSMManager = target as FSMManager;
                if (enermyFSMManager != null)
                {
                    //根据被攻击状态计算                
                }
            }
        }
    }
   
}