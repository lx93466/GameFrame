using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerDriveMoving : GameBehaviour
{
    Rigidbody m_rigidbody = null;

    float m_hValue = 0;

    float m_vValue = 0;

    Vector3 m_velocity;

    Player m_player = GameApp.GetInstance().m_player;

    protected override void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        RegisterMsg(PlayerMsg.moveMsg, Move);
    }

    void Move(Hashtable args)
    {
        m_hValue = Tools.ToFloat(args["H"].ToString());
       
        m_vValue = Tools.ToFloat(args["V"].ToString());

        m_velocity.x = m_vValue;

        m_velocity.z = m_hValue;

        m_rigidbody.velocity = m_velocity * m_player.m_speed;
    }
}
