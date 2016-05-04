using UnityEngine;
using System.Collections;
using GameFrame;

class MsgUITest : UIBase
{
    protected override void Init()
    {
        base.Init();

        m_path = "test";

        m_file = "MsgTestCanvas";

        m_containBackgroud = true;

        m_clickBackgroud = true;
    }

    public static UIBase GetInstance()
    {
        return Singleton<MsgUITest>.GetInstance();
    }
}
