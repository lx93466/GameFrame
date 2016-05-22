using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyLogic : GameBehaviour
{
    EnermyAnimation m_enermyAnimation = null;
    BattleAttributes m_battleAttributes = null;

    float m_attackTime = 0;//距离上次攻击时间
    
    protected override void Init()
    {
        base.Init();

        m_battleAttributes = Tools.GetComponent<BattleAttributes>(gameObject);
        m_enermyAnimation = Tools.GetComponent<EnermyAnimation>(gameObject);

        BattleController.GetInstance().m_enermiesTransform.Add(transform);
        m_battleAttributes.Init(4f, 200, 2, 10);

    }
    protected override void Uninit()
    {
        base.Uninit();
        BattleController.GetInstance().m_enermiesTransform.Remove(transform);
    }
    
    //攻击
    void Attack(Transform heroTransform)
    {
        if (heroTransform != null)
        {
            HeroLogic heroLogic = heroTransform.GetComponent<HeroLogic>();
            heroLogic.BeAttacked(transform.GetComponent<BattleAttributes>());

            //有转向动作时，动画播放会很奇怪
            //Vector3 pos = heroTransform.position;
            //pos.y = 0;
            //transform.rotation = Quaternion.LookRotation(transform.InverseTransformPoint(pos));
           // transform.LookAt(pos);
            m_enermyAnimation.AttackAnimation();
        }
    }

    void Idle()
    {
      //  m_enermyAnimation.StandAnimation();
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

    void Update()
    {
        m_attackTime += Time.deltaTime;

        if (m_attackTime > m_battleAttributes.m_attackTime)
        {
            m_attackTime = 0f;
            
            Transform heroTransform = BattleController.GetInstance().EnermyGetAttackableHero(transform);
            if (heroTransform != null)
            {
                Attack(heroTransform);
            }
        }      
    }
}