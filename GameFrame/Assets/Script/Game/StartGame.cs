using UnityEngine;
using System.Collections;
using GameFrame;

public class StartGame : MonoBehaviour {

    void Awake()
    {
        ConfigManager.GetInstance().Init();

        UIManager.GetInstance().Init();

        UIManager.GetInstance().RegisterUI(UIType.LoginUI, LoginUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.RegisterUI, RegisterUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.MainUI, MainUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.PersonalInfoUI, PersonalInfoUI.GetInstance);
    }
    void Start()
    {
        UIManager.GetInstance().OpenUI(UIType.LoginUI);
    }
}
