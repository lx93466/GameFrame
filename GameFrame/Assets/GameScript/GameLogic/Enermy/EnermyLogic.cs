using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyLogic : GameBehaviour
{
    public FSMManager m_fsmManager = new FSMManager();

    protected override void Init()
    {
        if (BattleController.m_battleController != null)
        {
            BattleController.m_battleController.m_enermyTransforms.Add(transform);
        }
        m_fsmManager.AddState(new EnermyMoveState(transform));
    }
    protected override void Uninit()
    {
        base.Uninit();
        if (BattleController.m_battleController != null)
        {
           BattleController.m_battleController.m_enermyTransforms.Remove(transform);
        }
    }    
}