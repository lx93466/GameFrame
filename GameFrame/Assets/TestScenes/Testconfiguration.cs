using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFrame;

public class Testconfiguration : MonoBehaviour
{

    void Awake()
    {
        ConfigManager.GetInstance().Init();
    }

	// Use this for initialization
	void Start () 
    {
        var testConfigData = TestConfig.GetInstance().GetAllConfigData();
        foreach (TestConfigData config in testConfigData)
        {
            Debug.Log(config.m_name + "   " + config.m_sex + "    " + config.m_age);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
