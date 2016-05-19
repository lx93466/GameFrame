using UnityEngine;
using System.Collections.Generic;
using GameFrame;

public class BattleController : Singleton<BattleController> 
{
    public HashSet<Transform> m_enermiesTransform = new HashSet<Transform>();

    public Transform m_playerTransform = null;

    HashSet<Transform> PlayerGetAttackableEnermies(AttackDirection direction = AttackDirection.Forward)
    {
        HashSet<Transform> enermies = new HashSet<Transform>();

        if (m_playerTransform != null)
        {
            foreach (var enermy in m_enermiesTransform)
            {
                Vector3 pos = m_playerTransform.InverseTransformPoint(enermy.transform.position);
               
                float distance = Vector3.Distance(Vector3.zero, pos);
               
                if (direction == AttackDirection.Forward)
                {
                    if (pos.z > 0)
                    {
                        if (distance < GameApp.GetInstance().m_player.m_attackDistance)
                        {
                            enermies.Add(enermy);
                        }
                    }
                }
                else if (direction == AttackDirection.Around)
                {
                    if (distance < GameApp.GetInstance().m_player.m_attackDistance)//当前玩家只有一个英雄
                    {
                        enermies.Add(enermy);
                    }
                }
            }
        }
        return enermies;
    }

    Transform EnermyGetAttackablePlayer(Transform enermyTransform, AttackDirection direction = AttackDirection.Forward)
    {
        Transform player = null;

        if (enermyTransform != null && m_playerTransform != null)
        {
            Vector3 pos = enermyTransform.InverseTransformPoint(m_playerTransform.transform.position);
               
            float distance = Vector3.Distance(Vector3.zero, pos);
               
            if (direction == AttackDirection.Forward)
            {
                if (pos.z > 0)
                {
                    if (distance < enermyTransform.GetComponent<Enermy>().m_attackDistance)
                    {
                        player = m_playerTransform;
                    }

                }
            }
            else if (direction == AttackDirection.Around)
            {
                if (distance < enermyTransform.GetComponent<Enermy>().m_attackDistance)
                {
                    player = m_playerTransform;
                }
            }           
        }
        return player;
    }
}
