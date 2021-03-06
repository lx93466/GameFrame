﻿using UnityEngine;
using System.Collections;
using GameFrame;

public class HeroDriveMoving : GameBehaviour
{
    Rigidbody m_rigidbody = null;

    Vector3 m_velocity = Vector3.zero;

    Hero m_hero = GameApp.GetInstance().m_hero;

    Vector3 m_relativePos = new Vector3(5, 10, 10);

    Quaternion m_rotation;

    protected override void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            m_velocity.x = -h * GameApp.GetInstance().m_hero.m_speed;
            m_velocity.z = -v * GameApp.GetInstance().m_hero.m_speed;
            transform.rotation = Quaternion.LookRotation(m_velocity);
            m_velocity.y = m_rigidbody.velocity.y;
            m_rigidbody.velocity = m_velocity;
        }
        else
        {
            StopMove();
        }
    }

    public void StopMove()
    {
        m_velocity = Vector3.zero;
        m_velocity.y = m_rigidbody.velocity.y;
        m_rigidbody.velocity = m_velocity;
        m_rotation = transform.rotation;
        m_rotation.x = 0;
        m_rotation.z = 0;
        transform.rotation = m_rotation;
       
    }
}
