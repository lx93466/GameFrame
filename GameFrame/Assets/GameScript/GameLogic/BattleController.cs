using UnityEngine;
using System.Collections.Generic;
using GameFrame;

public class BattleController : Singleton<BattleController> 
{
    public HashSet<Transform> m_enermiesTransform = new HashSet<Transform>();

    public Transform m_heroTransform = null;

    public HashSet<Transform> HeroGetAttackableEnermies(AttackDirection direction = AttackDirection.Forward)
    {
        HashSet<Transform> enermies = new HashSet<Transform>();

        if (m_heroTransform != null)
        {
            foreach (var enermy in m_enermiesTransform)
            {
                Vector3 pos = m_heroTransform.InverseTransformPoint(enermy.transform.position);
               
                float distance = Vector3.Distance(Vector3.zero, pos);
               
                if (direction == AttackDirection.Forward)
                {
                    if (pos.z > 0)
                    {
                        if (distance < GameApp.GetInstance().m_hero.m_attackDistance)
                        {
                            enermies.Add(enermy);
                        }
                    }
                }
                else if (direction == AttackDirection.Around)
                {
                    if (distance < GameApp.GetInstance().m_hero.m_attackDistance)//当前玩家只有一个英雄
                    {
                        enermies.Add(enermy);
                    }
                }
            }
        }
        return enermies;
    }

    public Transform EnermyGetAttackableHero(Transform enermyTransform, AttackDirection direction = AttackDirection.Forward)
    {
        Transform hero = null;

        if (enermyTransform != null && m_heroTransform != null)
        {
            Vector3 pos = enermyTransform.InverseTransformPoint(m_heroTransform.transform.position);
               
            float distance = Vector3.Distance(Vector3.zero, pos);
               
            if (direction == AttackDirection.Forward)
            {
                if (pos.z > 0)
                {
                    if (distance < enermyTransform.GetComponent<BattleAttributes>().m_attackDistance)
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
}
