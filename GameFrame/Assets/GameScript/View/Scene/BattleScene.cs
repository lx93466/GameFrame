using GameFrame;

class BattleScene : SceneBase
{
    protected override void BeforeOpen()
    {
        base.BeforeOpen();

        m_scenePath = "Scenes";

        m_sceneFile = "BattleScene";

        m_mainUIType = UIType.BattleUI;
    }

    public static BattleScene GetInstance()
    {
        return Singleton<BattleScene>.GetInstance();
    }
}
