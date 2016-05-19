using UnityEngine;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainUI : UIBase
{
    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "MainUI";

        m_containBackgroud = false;

        m_closeAllPreUI = true;
    }

    protected override void AftertOpen()
    {
        RegisterUIEvent("LeftTop/HeadIcon", OnOpenPersonalInfo);

        RegisterUIEvent("StartBattle", OnOpenBattleScene);
    }

    public static MainUI GetInstance()
    {
        return Singleton<MainUI>.GetInstance();
    }

    private void OnOpenPersonalInfo(PointerEventData data)
    {
        UIManager.GetInstance().OpenUI(UIType.PersonalInfoUI);
    }

    private void OnOpenBattleScene(PointerEventData data)
    {
        GameSceneManager.GetInstance().OpenScene(SceneType.BattleScene);
    }
}
