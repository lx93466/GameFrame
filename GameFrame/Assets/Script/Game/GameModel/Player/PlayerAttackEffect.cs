using UnityEngine;
using System.Collections;
using GameFrame;

class PlayerAttackEffect : GameBehaviour
{
    Effect m_attackEffect1 = null;
    Effect m_attackEffect2 = null;

    protected override void Init()
    {
        base.Init();

        m_attackEffect1 = transform.Find("Attack1Effect").GetComponent<Effect>();
        m_attackEffect2 = transform.Find("Attack2Effect").GetComponent<Effect>();

    }

    void AttackEffect(string effect)
    {
        Debug.Log(effect);
        if (effect == "attack1" && m_attackEffect1)
        {
            m_attackEffect1.ShowEffect();
        }
        else if (effect == "attack2" && m_attackEffect2)
        {
            m_attackEffect2.ShowEffect();
        }
    }
}

