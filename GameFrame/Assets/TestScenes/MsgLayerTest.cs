using UnityEngine;
using System.Collections;
using GameFrame;

class MsgUITest : UIBase
{
    protected override void BeforeOpen()
    {
        base.BeforeOpen();

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
