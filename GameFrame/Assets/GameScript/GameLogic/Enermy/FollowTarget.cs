using UnityEngine;
using System.Collections;
using GameFrame;

public class FollowTarget : GameBehaviour
{
    public Transform m_target = null;
    CharacterController m_characterCtrl = null;
    BattleAttributes m_battleAttributes = null;
    EnermyAnimation m_enermyAnimation = null;
    public HpBar m_hpBar = null;
    protected override void Init()
    {
        m_battleAttributes = Tools.GetComponent<BattleAttributes>(gameObject);
        m_characterCtrl = transform.GetComponent<CharacterController>();
        m_enermyAnimation = Tools.GetComponent<EnermyAnimation>(gameObject);
        base.Init();
        m_hpBar = Tools.GetComponent<HpBar>(gameObject);

        m_enermyAnimation.MoveAnimation();
    }
	// Update is called once per frame
	void Update () 
    {
        if (m_target != null && m_characterCtrl != null)
        {
            transform.LookAt(m_target);
            float distance = Vector3.Distance(transform.position, m_target.position);
            if (distance > m_battleAttributes.m_attackDistance)
            {
                m_characterCtrl.SimpleMove(transform.forward * EnermyLogic.m_instance.m_battleAttributes.m_speed);
                m_enermyAnimation.MoveAnimation();
            }
            else
            {
                m_enermyAnimation.EndMoveAnimation();
            }
            m_hpBar.UpdateHp(transform.Find("HpBarPoint").transform.position, m_battleAttributes.m_hp, m_battleAttributes.m_curHp, m_battleAttributes.m_name);
        }
	}
}
