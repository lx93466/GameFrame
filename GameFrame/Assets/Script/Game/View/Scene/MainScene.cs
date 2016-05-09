using UnityEngine;
using System.Collections;
using GameFrame;

class MainScene : SceneBase
{
    protected override void BeforeOpen()
    {
        base.BeforeOpen();

        m_scenePath = "Scenes";

        m_sceneFile = "MainScene";

        m_mainUIType = UIType.MainUI;
    }

    public static MainScene GetInstance()
    {
        return Singleton<MainScene>.GetInstance();
    }
}
