using UnityEngine;
using System.Collections;
using GameFrame;
using System;

public class HeroAutoMoving : GameBehaviour
{
    Animator m_animator = null;

    protected override void Init()
    {
        m_animator = GetComponent<Animator>();

        RegisterMsg(HeroMsg.heroMoveMsg, Move);
    }

    void Move(Hashtable args)
    {
     
    }
}

