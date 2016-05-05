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

    public static MainUI GetInstance()
    {
        return Singleton<MainUI>.GetInstance();
    }
}
