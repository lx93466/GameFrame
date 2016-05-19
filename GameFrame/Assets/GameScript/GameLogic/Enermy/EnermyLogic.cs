using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyLogic : GameBehaviour
{
    protected override void Init()
    {
        base.Init();
        BattleController.GetInstance().m_enermiesTransform.Add(transform);
        Tools.GetComponent<BattleAttributes>(gameObject).Init(1f, 200, 3, 10);

    }
    protected override void Uninit()
    {
        base.Uninit();
        BattleController.GetInstance().m_enermiesTransform.Remove(transform);
    }
    void Attack()
    {
        Transform heroTransform = BattleController.GetInstance().EnermyGetAttackableHero(transform);
        if (heroTransform)
        {
            HeroLogic heroLogic = heroTransform.GetComponent<HeroLogic>();
            heroLogic.BeAttacked(transform.GetComponent<BattleAttributes>());
        }
    }

    public void BeAttacked(BattleAttributes heroAttributes, HeroAttackType attackType = HeroAttackType.Attack1)
    {
        if (heroAttributes != null)
        {
            BattleAttributes enermyBattleAttributes = transform.GetComponent<BattleAttributes>();
            if (attackType == HeroAttackType.Attack1)
	        {
                enermyBattleAttributes.m_hp -= heroAttributes.m_attackDamage;		 
	        }
            else if (attackType == HeroAttackType.Attack2)
            {
                enermyBattleAttributes.m_hp -= heroAttributes.m_attackDamage;		                 
            }
            else if (attackType == HeroAttackType.Skill1)
            {
                enermyBattleAttributes.m_hp -= heroAttributes.m_skill1Damage;		                                 
            }
            else if (attackType == HeroAttackType.Skill2)
            {
                enermyBattleAttributes.m_hp -= heroAttributes.m_skill2Damage;
            }
            else if (attackType == HeroAttackType.Skill3)
            {
                enermyBattleAttributes.m_hp -= heroAttributes.m_skill3Damage;
            }

        }
    }
}