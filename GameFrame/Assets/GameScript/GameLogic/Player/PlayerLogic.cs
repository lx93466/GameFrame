using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerLogic : GameBehaviour {

    Hashtable args = new Hashtable();

    protected override void Init()
    {
        base.Init();

        BattleController.GetInstance().m_playerTransform = transform;

        RegisterMsg(PlayerMsg.attackMsg, PlayerAttack);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        float v = Input.GetAxis("Vertical");
       
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            args["x"] = -h;
            args["z"] = -v;

            PlayerMsg.moveMsg.Hashtable = args;

            MsgManager.GetInstance().DispatchMsg(PlayerMsg.moveMsg, args);
        }
        else
        {
            MsgManager.GetInstance().DispatchMsg(PlayerMsg.standMsg);
        }
    }

    void PlayerAttack(Hashtable arg)
    {

    }
}
