using UnityEngine;
using System.Collections;
using GameFrame;

public class PlayerDriveMoving : GameBehaviour
{
    Rigidbody m_rigidbody = null;

    float m_hValue = 0;

    float m_vValue = 0;

    Vector3 m_velocity = Vector3.zero;

    Player m_player = GameApp.GetInstance().m_player;

    Vector3 m_relativePos = new Vector3(5, 10, 10);

    protected override void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        RegisterMsg(PlayerMsg.moveMsg, Move);
    }

    void Move(MsgArg args)
    {
        m_velocity.x = args.v4.x * m_player.m_speed;

        m_velocity.y = m_rigidbody.velocity.y;

        m_velocity.z = args.v4.z * m_player.m_speed;

        m_rigidbody.velocity = m_velocity;

        transform.rotation = Quaternion.LookRotation(args.v4);
        
        args.v4 = transform.position + m_relativePos;

     //   CameraFollowing.cameraMovingMsg.msgArg = args;

     //   MsgManager.GetInstance().DispatchMsg(CameraFollowing.cameraMovingMsg);
    }

    protected override void Uninit()
    {
        base.Uninit();
    }

    void Update()
    {
       // Debug.Log("Update:" + this);
    }
}
