using UnityEngine;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PersonalInfoUI : UIBase
{
    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "PersonalInfoUI";

        m_containBackgroud = true;

        m_clickBackgroud = true;

        m_closePreUI = false;
    }

    public static PersonalInfoUI GetInstance()
    {
        return Singleton<PersonalInfoUI>.GetInstance();
    }
}
