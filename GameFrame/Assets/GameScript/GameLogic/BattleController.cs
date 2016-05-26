using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GameFrame;

public class BattleController : GameBehaviour
{
    public HashSet<Transform> m_enermyTransforms = new HashSet<Transform>();
    public static BattleController m_battleController = null;

    private Transform heroTransform;

    public Transform m_heroTransform
    {
        set
        {
            heroTransform = value;
            m_heroLogic = Tools.GetComponent<HeroLogic>(heroTransform.gameObject);
        }
        get { return heroTransform; }
    }

    public HeroLogic m_heroLogic = null;

    Hashtable args = new Hashtable();

    public HashSet<FSMManager> HeroGetAttackableEnermies(AttackDirection direction = AttackDirection.Forward)
    {
        HashSet<FSMManager> enermyFSMManager = new HashSet<FSMManager>();

        if (m_heroTransform != null)
        {
            foreach (var enermy in m_enermyTransforms)
            {
                Vector3 pos = m_heroTransform.InverseTransformPoint(enermy.transform.position);

                float distance = Vector3.Distance(enermy.position, m_heroTransform.position);
               
                if (direction == AttackDirection.Forward)
                {
                    if (pos.z > 0)
                    {
                        if (distance < GameApp.GetInstance().m_hero.m_attackDistance)
                        {
                            enermyFSMManager.Add(enermy.GetComponent<EnermyLogic>().m_fsmManager);
                        }
                    }
                }
                else if (direction == AttackDirection.Around)
                {
                    if (distance < GameApp.GetInstance().m_hero.m_attackDistance)//当前玩家只有一个英雄
                    {
                        enermyFSMManager.Add(enermy.GetComponent<EnermyLogic>().m_fsmManager);
                    }
                }
            }
        }
        return enermyFSMManager;
    }

    public Transform EnermyGetAttackableHero(Transform enermyTransform, AttackDirection direction = AttackDirection.Forward)
    {
        Transform hero = null;

        if (enermyTransform != null && m_heroTransform != null)
        {
            Vector3 pos = enermyTransform.InverseTransformPoint(m_heroTransform.transform.position);

            float distance = Vector3.Distance(enermyTransform.position, m_heroTransform.transform.position);

            if (direction == AttackDirection.Forward)
            {
                if (pos.z > 0)
                {
                    float attackDistance = enermyTransform.GetComponent<BattleAttributes>().m_attackDistance;
                    if (distance < attackDistance)
                    {
                        hero = m_heroTransform;
                    }

                }
            }
            else if (direction == AttackDirection.Around)
            {
                if (distance < enermyTransform.GetComponent<BattleAttributes>().m_attackDistance)
                {
                    hero = m_heroTransform;
                }
            }           
        }
        return hero;
    }

    protected override void GameFixedUpdate()
    {
        if (m_heroTransform != null)
        {
            foreach (Transform enermyTransform in m_enermyTransforms)
            {
                args.Clear();
                args["heroTransform"] = m_heroTransform;
                Tools.GetComponent<EnermyLogic>(enermyTransform.gameObject).m_fsmManager.ChangeState(FSMStateIdDefine.move, args);
            }
        }
    }

    protected override void Init()
    {
        m_battleController = this;

        RunFixedUpdate();
    }
}
