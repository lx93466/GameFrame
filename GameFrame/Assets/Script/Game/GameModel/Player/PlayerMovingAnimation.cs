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
    }

    void Stand(Hashtable args)
    {
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", false);
        }
    }

    void Move(Hashtable args)
    {
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", true);
        }
    }
}
