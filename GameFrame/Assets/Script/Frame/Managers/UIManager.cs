using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace GameFrame
{
    public delegate UIBase GetUIInstanceDelegate();

    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<UIType, GetUIInstanceDelegate> m_UIDelegates = new Dictionary<UIType, GetUIInstanceDelegate>();//<注册的UI类型, 获取注册UI实例的方法>

        public Stack<UIType> m_stackOpenedUI = new Stack<UIType>(); //已经打开的UI栈

        public UIType m_curOpenedUIType = UIType.None; //当前最顶层UI

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

        public void OpenUI(UIType uiType)
        {
            GetUIInstanceDelegate uiDelegate = null;

            if (m_UIDelegates.TryGetValue(uiType, out uiDelegate))
            {
                UIBase uiBase = uiDelegate();
               
                if (uiBase.m_closeAllPreUI)
                {                                    
                    bool hasUI = true;

                    while (hasUI)
                    {
                        if (m_stackOpenedUI.Count > 0)
                        {
                            UIType tempUIType = m_stackOpenedUI.Peek();
                           
                            CloseUI(tempUIType);
                        }
                        else
                        {
                            hasUI = false;
                        }
                    }                
                }
                else
                {
                    if (uiBase.m_closePreUI == true)
                    {                                        
                        CloseUI(m_curOpenedUIType);             
                    }
                }
               
                uiBase.Open();
                m_curOpenedUIType = uiType;
                m_stackOpenedUI.Push(uiType);
                Tools.AddTip("Open UI:" + uiBase.m_file);
            }
            else
            {
                 Tools.AddWarming("You are not Registered UI:" + uiType.ToString());
            }
        }

        public void CloseUI(UIType uiType, bool isDestroy = true)
        {
            GetUIInstanceDelegate uiDelegate = null;

            if (m_stackOpenedUI.Count > 0)
            {
                m_stackOpenedUI.Pop();
              
                if (m_stackOpenedUI.Count > 0 )
                {
                    m_curOpenedUIType = m_stackOpenedUI.Peek();
                }
                else
                {
                    m_curOpenedUIType = UIType.None;
                }
            } 

            if (m_UIDelegates.TryGetValue(uiType, out uiDelegate))
            {
                uiDelegate().Close(isDestroy);
            }
        }

        public override void Init()
        {
            MsgManager.GetInstance().RegisterMsg(MsgId.ReinitUIManager, ClearOpenedUITemp);
        }

        public void ClearOpenedUITemp(Hashtable args)
        {
            m_stackOpenedUI.Clear();
          
            m_curOpenedUIType = UIType.None;
        }
    }
}
