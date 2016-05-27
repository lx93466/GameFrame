using UnityEngine;
using System.Collections;
using GameFrame;

class HeroAttackEffect : GameBehaviour
{
    Effect m_attackEffect1 = null;
    Effect m_attackEffect2 = null;

    Hashtable m_ht = new Hashtable();
    protected override void Init()
    {
        base.Init();
        m_attackEffect1 = transform.Find("Attack1Effect").GetComponent<Effect>();
        m_attackEffect2 = transform.Find("Attack2Effect").GetComponent<Effect>();
    }

    /// <summary>
    /// 动画事件中调用
    /// </summary>
    /// <param name="effect"></param>
    void AttackEffect(string effect)
    {
        Debug.Log(effect);
        if (effect == "attack1" && m_attackEffect1)
        {
            m_attackEffect1.gameObject.SetActive(true);
            m_attackEffect1.ShowEffect();

            m_ht["attackType"] = AttackType.Attack1;
            MsgManager.GetInstance().DispatchMsg(HeroMsgDefine.heroAttackMsg, m_ht);
        }
        else if (effect == "attack2" && m_attackEffect2)
        {
            m_attackEffect2.gameObject.SetActive(true);
            m_attackEffect2.ShowEffect();
         
            m_ht["attackType"] = AttackType.Attack2;
            MsgManager.GetInstance().DispatchMsg(HeroMsgDefine.heroAttackMsg, m_ht);
        }
    }

    /// <summary>
    /// 技能特效函数
    /// </summary>
    /// <param name="arg"></param>
    public void SkillEffect(AttackType attackType)
    {
        if (attackType == AttackType.Skill1)
        {
            PlaySkill1Effect();
        }
        else if (attackType == AttackType.Skill2)
        {
            PlaySkill2Effect();
        }
        else if (attackType == AttackType.Skill3)
        {
            PlaySkill3Effect();
        }
    }

    void PlaySkill1Effect()
    {

    }

    void PlaySkill2Effect()
    {

    }

    void PlaySkill3Effect()
    {

    }
}

