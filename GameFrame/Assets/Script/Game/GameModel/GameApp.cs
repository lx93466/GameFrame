﻿using GameFrame;

class GameApp : Singleton<GameApp>
{
    public Player m_player = new Player();

    public void StartGame()
    {
        GameSceneManager.GetInstance().OpenScene(SceneType.LoginScene);        
    }

    public void InitGame()
    {
        InitManagers();
        RegisterScenes();
        RegisterUIs();
    }

    private void RegisterUIs()
    {
        UIManager.GetInstance().RegisterUI(UIType.LoginUI, LoginUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.RegisterUI, RegisterUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.MainUI, MainUI.GetInstance);
        UIManager.GetInstance().RegisterUI(UIType.PersonalInfoUI, PersonalInfoUI.GetInstance);
    }

    private void RegisterScenes()
    {
        GameSceneManager.GetInstance().RegisterScene(SceneType.LoginScene, LoginScene.GetInstance);
        GameSceneManager.GetInstance().RegisterScene(SceneType.MainScene, MainScene.GetInstance);
    }

    private void InitManagers()
    {
        ConfigManager.GetInstance().Init();
        UIManager.GetInstance().Init();
        TimerManager.GetInstance().Init();
    }
}
