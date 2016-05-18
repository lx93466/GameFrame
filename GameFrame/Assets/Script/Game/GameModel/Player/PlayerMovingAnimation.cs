using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerMovingAnimation : GameBehaviour
{
    Animator m_animator = null;
    
    protected override void Init()
    {
        m_animator = GetComponent<Animator>();

        RegisterMsg(PlayerMsg.moveMsg, Move);

        RegisterMsg(PlayerMsg.standMsg, Stand);

        RegisterMsg(PlayerMsg.attack1Msg, Attack1);
    }

    void Stand(MsgArg args)
    {
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", false);
        }
    }

    void Move(MsgArg args)
    {
        Debug.Log("PlayerMovingAnimation: Move");
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", true);
        }
    }

    void Attack1(MsgArg args)
    {
        Debug.Log("PlayerMovingAnimation: Attack1");
        if (m_animator != null)
        {
            m_animator.SetTrigger("attack");
            iTween.MoveBy(this.gameObject, Vector3.forward * 3, 0.4f);
        }
    }
}
