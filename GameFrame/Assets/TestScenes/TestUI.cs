using UnityEngine;
using System.Collections;
using GameFrame;

public class TestUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // MsgUITest.GetInstance().Open();
        UIManager.GetInstance().Init();

       // UIManager.GetInstance().OpenUI(UIType.TestUI);
        
	}
	
}
