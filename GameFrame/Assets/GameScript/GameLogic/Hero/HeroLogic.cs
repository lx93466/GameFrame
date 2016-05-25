using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFrame;

public class HeroLogic : GameBehaviour
{

    public static HeroLogic m_instance = null;

    public FSMManager m_heroFSMManager = new FSMManager();


    protected override void Init()
    {
        base.Init();
        m_instance = this;
        BattleController.GetInstance().m_heroTransform = transform;
        m_heroFSMManager.AddState(new HeroStandState(transform));
        m_heroFSMManager.AddState(new HeroMoveState(transform));
        Tools.GetComponent<HeroMove>(gameObject).Run();
    }

    protected override void Uninit()
    {

    }
}