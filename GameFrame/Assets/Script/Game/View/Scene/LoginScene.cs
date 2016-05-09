using UnityEngine;
using System.Collections;
using GameFrame;

class LoginScene : SceneBase
{
    protected override void BeforeOpen()
    {
        base.BeforeOpen();

        m_scenePath = "Scenes";

        m_sceneFile = "LoginScene";

        m_mainUIType = UIType.LoginUI;
    }

    public static LoginScene GetInstance()
    {
        return Singleton<LoginScene>.GetInstance();
    }
}
