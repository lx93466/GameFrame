using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyLogic_old : GameBehaviour
{
    public EnermyAnimation m_enermyAnimation = null;
    public BattleAttributes m_battleAttributes = null;
    public FollowTarget m_followTarget = null;

    public FSMManager m_fsmManager = new FSMManager();

    protected override void Init()
    {
        base.Init();

        m_battleAttributes = Tools.GetComponent<BattleAttributes>(gameObject);
        m_enermyAnimation = Tools.GetComponent<EnermyAnimation>(gameObject);
        m_followTarget = Tools.GetComponent<FollowTarget>(gameObject);
        m_followTarget.m_target = BattleController.m_battleController.m_heroTransform;
        BattleController.m_battleController.m_enermyTransforms.Add(transform);
        m_battleAttributes.Init(2f, 200, 3, 10);

    }
    protected override void Uninit()
    {
        base.Uninit();
        BattleController.m_battleController.m_enermyTransforms.Remove(transform);
    }
    
    //攻击
    void Attack(Transform heroTransform)
    {
        if (heroTransform != null)
        {
            HeroLogic_old heroLogic = heroTransform.GetComponent<HeroLogic_old>();
//            heroLogic.BeAttacked(transform.GetComponent<BattleAttributes>());

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

    public void BeAttacked(BattleAttributes heroAttributes, AttackType attackType = AttackType.Attack1)
    {
        if (heroAttributes != null)
        {
            BattleAttributes enermyBattleAttributes = transform.GetComponent<BattleAttributes>();
            if (attackType == AttackType.Attack1)
	        {
                enermyBattleAttributes.m_curHp -= heroAttributes.m_attackDamage;		 
	        }
            else if (attackType == AttackType.Attack2)
            {
                enermyBattleAttributes.m_curHp -= heroAttributes.m_attackDamage;		                 
            }
            else if (attackType == AttackType.Skill1)
            {
                enermyBattleAttributes.m_curHp -= heroAttributes.m_skill1Damage;		                                 
            }
            else if (attackType == AttackType.Skill2)
            {
                enermyBattleAttributes.m_curHp -= heroAttributes.m_skill2Damage;
            }
            else if (attackType == AttackType.Skill3)
            {
                enermyBattleAttributes.m_curHp -= heroAttributes.m_skill3Damage;
            }
            if (enermyBattleAttributes.m_curHp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        m_enermyAnimation.DieAnimation();
        TimerManager.GetInstance().DelayCall(Disappear, 5f);
    }
    void Disappear()
    {
        BattleController.m_battleController.m_enermyTransforms.Remove(transform);
        transform.GetComponent<HpBar>().Disappear(m_battleAttributes.m_name);
        GameObject.Destroy(gameObject);
    }
    void Update()
    {
        //m_attackTime += Time.deltaTime;

        //if (m_attackTime > m_battleAttributes.m_attackTime)
        //{
        //    m_attackTime = 0f;
            
        //    Transform heroTransform = BattleController.m_battleController.EnermyGetAttackableHero(transform);
        //    if (heroTransform != null)
        //    {
        //        Attack(heroTransform);
        //    }
        //}
        //else
        //{
        //    m_enermyAnimation.StandAnimation();
        //}

    }

}