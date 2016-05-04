using UnityEngine;
using System.Collections;
using GameFrame;
using UnityEngine.EventSystems;

public class LoginUI : UIBase 
{
    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "LoginCanvas";

        m_containBackgroud = false;

    }

    protected override void AftertOpen()
    {
        Transform btn = m_root.Find("LoginButton");        
        if (btn != null)
        {
            Tools.GetComponent<UIEventListener>(btn.gameObject).onClick = OnClickLogin;   
        }

        btn = m_root.Find("RegisterButton");
        if (btn != null)
        {
            Tools.GetComponent<UIEventListener>(btn.gameObject).onClick = OnClickRegister;
        }
    }
    public void OnClickLogin(PointerEventData data)
    {
        Debug.Log("OnClickLogin");
    }

    public void OnClickRegister(PointerEventData data)
    {
        Debug.Log("OnClickRegister");
    }
}
