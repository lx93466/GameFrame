using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerLogic : GameBehaviour {

    Vector3 m_velocity = new Vector3();

    Hashtable args = new Hashtable();

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        float v = Input.GetAxis("Vertical");
       
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            m_velocity.x = v;

            m_velocity.y = h;

            args.Add("H", h);
            args.Add("V", v);

            MsgManager.GetInstance().DispatchMsg(PlayerMsg.moveMsg, args);
        }
        else
        {
            MsgManager.GetInstance().DispatchMsg(PlayerMsg.standMsg, args);
        }
    }
}
