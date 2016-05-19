using UnityEngine;
using System.Collections;
using GameFrame;


public class CameraFollowing : GameBehaviour {
    
    Transform m_target = null;
   
    Vector3 m_relativePos = new Vector3(5, 10, 10);
   
    protected override void Init()
    {
        m_target = GameObject.Find("Hero").GetComponent<Transform>();
    }

    void Update()
    {
        if (m_target != null)
        {
            transform.position = m_target.position + m_relativePos;                     
        }
    }
}
