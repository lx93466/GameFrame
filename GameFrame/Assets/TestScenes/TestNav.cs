using UnityEngine;
using System.Collections;

public class TestNav : MonoBehaviour {
    NavMeshAgent m_agent;
	// Use this for initialization
	void Start () {
        m_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (m_agent != null)
                {
                    m_agent.enabled = true;
                    m_agent.SetDestination(hit.point);
                   // transform.LookAt(hit.point);
                   // HeroLogic.m_instance.m_heroFSMManager.ChangeState(HeroStateDefine.move);
                    Debug.Log(hit.point);
                    return;//下一帧开始计算导航想个数据
                }
            }
        }
	}
}
