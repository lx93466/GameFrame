using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerLogic : GameBehaviour {

    PlayerAttackEffect m_attack1Effect = null;

    MsgArg args = new MsgArg();

    protected override void Init()
    {
        base.Init();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        float v = Input.GetAxis("Vertical");
       
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            args.v4 = new Vector4(-h, 0, -v);

            PlayerMsg.moveMsg.msgArg = args;

            MsgManager.GetInstance().DispatchMsg(PlayerMsg.moveMsg);
        }
        else
        {
            MsgManager.GetInstance().DispatchMsg(PlayerMsg.standMsg);
        }
    }
}
