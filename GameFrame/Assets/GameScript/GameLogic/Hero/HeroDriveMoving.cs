using UnityEngine;
using System.Collections;
using GameFrame;

public class HeroDriveMoving : GameBehaviour
{
    Rigidbody m_rigidbody = null;

    Vector3 m_velocity = Vector3.zero;

    Hero m_hero = GameApp.GetInstance().m_hero;

    Vector3 m_relativePos = new Vector3(5, 10, 10);

    protected override void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Move(Vector3 speed)
    {      
        m_rigidbody.velocity = speed * m_hero.m_speed;

        transform.rotation = Quaternion.LookRotation(m_velocity);         
    }
}
