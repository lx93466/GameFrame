using UnityEngine;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegisterUI : UIBase
{
    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "RegisterUI";

        m_containBackgroud = true;

        m_clickBackgroud = true;

        m_closePreUI = false;
    }

    protected override void AftertOpen()
    {
        RegisterUIEvent("RegisterButton", OnRegister);   
    }

    public void OnRegister(PointerEventData eventData)
    {
        Transform name = m_root.Find("NameInputField");
        if (name != null)
        {
            InputField nameInput = name.GetComponent<InputField>();
            if (nameInput != null)
            {
                LoginSystem.GetInstance().m_loginName = nameInput.text;
            }
        }

        Transform password = m_root.Find("PwdInputField1");
        if (password != null)
        {
            InputField passwordInput = password.GetComponent<InputField>();
            if (passwordInput != null)
            {
                LoginSystem.GetInstance().m_loginPassword = passwordInput.text;
            }
        }

        MsgManager.GetInstance().DispatchMsg(MsgId.UpdateUI);

        UIManager.GetInstance().CloseUI(m_uiType);

        Debug.Log("账号注册成功");
    }

    public static RegisterUI GetInstance()
    {
        return Singleton<RegisterUI>.GetInstance();
    }
}
