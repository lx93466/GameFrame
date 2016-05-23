using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFrame;

public class HeroLogic : GameBehaviour {

    Hashtable args = new Hashtable();
    Rigidbody m_rigidbody = null;
    Vector3 m_velocity = Vector3.zero;

    HeroAnimation m_heroAnimation = null;
    HeroAttackEffect m_heroAttackEffect = null;
    HeroDriveMoving m_heroDriveMoving = null;
    HeroAutoMoving m_heroAutoMoving = null;
    BattleAttributes m_battleAttributes = null;
  
    protected override void Init()
    {
        base.Init();
        //初始化组件
        m_rigidbody = transform.GetComponent<Rigidbody>();
        m_rigidbody.freezeRotation = true;
        m_battleAttributes = Tools.GetComponent<BattleAttributes>(gameObject); 
        m_heroAnimation =  Tools.GetComponent<HeroAnimation>(gameObject);
        m_heroAttackEffect = Tools.GetComponent<HeroAttackEffect>(gameObject);
        m_heroDriveMoving = Tools.GetComponent<HeroDriveMoving>(gameObject);
        m_heroAutoMoving = Tools.GetComponent<HeroAutoMoving>(gameObject);
     
        //初始化战斗数据
        m_battleAttributes.Init(3f, 2000, 5, 20, 30, 30, 30);
        BattleController.GetInstance().m_heroTransform = transform;
      
        //注册消息
        RegisterMsg(HeroMsg.heroAttackMsg, AttackCallBack);
    }

    protected override void Uninit()
    {
        base.Uninit();
        BattleController.GetInstance().m_heroTransform = null;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        float v = Input.GetAxis("Vertical");
       
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            m_heroDriveMoving.Move();

            m_heroAnimation.MoveAnimation();
        }
        else
        {
            m_heroDriveMoving.StopMove();

            m_heroAnimation.StandAnimation();
        }
    }

    void AttackCallBack(Hashtable arg)
    {
        if (arg != null && arg.ContainsKey("attackType"))//普通攻击时，没有攻击类型
        {
            HeroAttackType attackType = (HeroAttackType)arg["attackType"];

            AttackEnermies(attackType);
            m_heroAnimation.AttackAnimation(attackType);
            m_heroAttackEffect.SkillEffect(attackType);
        }
        else//普通攻击，只触发普通攻击动画播放，在特效中，再发送攻击函数，包含普通攻击类型。
        {
            m_heroAnimation.AttackAnimation(HeroAttackType.None);
        }
    }
    /// <summary>
    /// 攻击敌人
    /// </summary>
    /// <param name="attackType"></param>
    void AttackEnermies(HeroAttackType attackType)
    {
        if (attackType == HeroAttackType.Attack1)
        {
            HashSet<Transform> enermiesTransform = BattleController.GetInstance().HeroGetAttackableEnermies();

            foreach (var enermyTransform in enermiesTransform)
            {
                EnermyLogic enermyLogic = enermyTransform.GetComponent<EnermyLogic>();
                enermyLogic.BeAttacked(m_battleAttributes);
            }
        }
    }
    public void BeAttacked(BattleAttributes enermyAttributes, HeroAttackType attackType = HeroAttackType.Attack1)
    {
        if (enermyAttributes != null)
        {
            BattleAttributes heroAttribute = transform.GetComponent<BattleAttributes>();
            heroAttribute.m_hp -= enermyAttributes.m_attackDamage;
        }
    }
}
