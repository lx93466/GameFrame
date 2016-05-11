using UnityEngine;
using System.Collections;
using GameFrame;
using System;

public class PlayerAutoMoving : GameBehaviour
{
    Animator m_animator = null;

    protected override void Init()
    {
        m_animator = GetComponent<Animator>();

        RegisterMsg(PlayerMsg.moveMsg, Move);
    }

    void Move(MsgArg args)
    {
     
    }
}

