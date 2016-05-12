using UnityEngine;
using System.Collections;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginUI : UIBase 
{
    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "LoginUI";

        m_containBackgroud = false;
    }

    protected override void AftertOpen()
    {
        RegisterUIEvent("LoginButton", OnClickLogin);
        RegisterUIEvent("RegisterButton", OnClickRegister);

        RegisterMsg(UIMsgDefine.UpdateUIMsg, UpdateUI);

        UpdateUI();
    }

    public static LoginUI GetInstance()
    {
        return Singleton<LoginUI>.GetInstance();
    }
    public void OnClickLogin(PointerEventData data)
    {
        GameSceneManager.GetInstance().OpenScene(SceneType.MainScene);
    }

    public void OnClickRegister(PointerEventData data)
    {
        UIManager.GetInstance().OpenUI(UIType.RegisterUI);
    }

    private void UpdateUI(MsgArg args = null)
    {
        if (m_root != null && IsVisible())
	    {
            Transform name = m_root.Find("NameInputField");
            
            if (name != null)
            {
                InputField nameInput = name.GetComponent<InputField>();

                if (nameInput != null)
                {
                    nameInput.text = LoginSystem.GetInstance().m_loginName;
                }
            }

            Transform password = m_root.Find("PWDInputField");

            if (password != null)
            {
                InputField passwordInput = password.GetComponent<InputField>();

                if (passwordInput != null)
                {
                    passwordInput.text = LoginSystem.GetInstance().m_loginPassword;
                }
            }
	    }
    }
}
