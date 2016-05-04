using UnityEngine;
using System.Collections;
using GameFrame;

public class StartGame : MonoBehaviour {

    void Awake()
    {
        ConfigManager.GetInstance().Init();

        UIManager.GetInstance().Init();

    }
    void Start()
    {
        UIManager.GetInstance().OpenUI(UIType.LoginUI);
    }
}
