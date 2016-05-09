/// <summary>
/// 消息定义
/// </summary>
public enum MsgId
{
    testMsgId,      //测试消息
    UpdateUI,       //更新UI消息
    ReinitUIManager //重新初始化UIManager
}

/// <summary>
/// UI类型定义，如：背包、商城等。
/// </summary>
public enum UIType
{
    None,
    LoginUI,
    RegisterUI,
    MainUI,
    PersonalInfoUI
}

/// <summary>
/// Scene类型定义：
/// </summary>
public enum SceneType
{
    None,
    // 登陆场景
    LoginScene,
    //游戏世界主场景
    MainScene
}

