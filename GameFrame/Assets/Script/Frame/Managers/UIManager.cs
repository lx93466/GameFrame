using UnityEngine;
using System.Collections.Generic;
namespace GameFrame
{
    public delegate UIBase GetUIInstanceDelegate();

    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<UIType, GetUIInstanceDelegate> m_UIDelegates = new Dictionary<UIType, GetUIInstanceDelegate>();//<注册的UI类型, 获取注册UI实例的方法>

        public Stack<UIType> m_stackOpenedUI = new Stack<UIType>(); //已经打开的UI栈

        //要使用的UI，必须注册
        public void RegisterUI(UIType uiType, GetUIInstanceDelegate uiDelegate)
        {
            GetUIInstanceDelegate tempDelegate = null;

            if (!m_UIDelegates.TryGetValue(uiType, out tempDelegate))
            {
                uiDelegate().m_uiType = uiType;

                m_UIDelegates.Add(uiType, uiDelegate);                         
            }
        }

        public void Init()
        {
            RegisterUI(UIType.TestUI, MsgUITest.GetInstance);
        }

        public void ShowUI(UIType uiType)
        {
            GetUIInstanceDelegate uiDelegate = null;

            if (m_UIDelegates.TryGetValue(uiType, out uiDelegate))
            {
                UIBase uiBase = uiDelegate();
               
                if (uiBase.m_closeAllPreUI)
                {                   
                    UIBase tempUiBase = null;

                    GetUIInstanceDelegate tempDelegate = null;

                    foreach (var tempUiType in m_stackOpenedUI)
                    {
                        if (m_UIDelegates.TryGetValue(tempUiType, out tempDelegate))
                        {
                            tempUiBase = tempDelegate();

                            if (tempUiBase.m_unclosable == false)
                            {
                                CloseUI(tempUiType);
                            }
                        }
                    }
                }
                else
                {
                    if (uiBase.m_closePreUI == true && uiBase.m_unclosable == false)
                    {
                        UIType tempType = m_stackOpenedUI.Pop();
                        CloseUI(tempType);
                    }
                }
               
                uiBase.Open();
                m_stackOpenedUI.Push(uiType);
            }
        }

        public void CloseUI(UIType uiType, bool isDestroy = true)
        {
            GetUIInstanceDelegate uiDelegate = null;

            if (m_UIDelegates.TryGetValue(uiType, out uiDelegate))
            {
                uiDelegate().Close(isDestroy);
            }
        }    
    }
}
