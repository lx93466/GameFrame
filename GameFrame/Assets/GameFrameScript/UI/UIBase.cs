using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GameFrame
{
    /// <summary>
    /// 一个UI必须是一个画布：Canvas。
    /// 子类必须要有方法：public static UIBase GetInstance()
    /// 以获取单例
    /// </summary>
    public abstract class UIBase
    {
        protected Transform m_root = null;

        protected bool m_visible = false;

        protected string m_path = "";//文件所在路径

        public string m_file = "";//文件名称

        protected int m_backgroudMusicId = -1;

        private string m_fullPath = "";

        protected bool m_containBackgroud = true; //是否包含半透明背景

        protected bool m_clickBackgroud = true;  // 半透明背景是否可点击关闭

        public bool m_closePreUI = true; //打开此UI时，是否关闭前一个打开的UI(如果前面只有一个UI，则不关闭)。

        public bool m_closeAllPreUI = false; //打开此UI时，是否关闭打开的所有UI。

        public UIType m_uiType;

        private Dictionary<Msg, MsgCallback> m_registeredMsgIds = new Dictionary<Msg,MsgCallback>();

        protected UIBase()
        {
            BeforeOpen();
        }

        /// <summary>
        /// 重写此函数时，初始化加载界面所需参数
        ///     m_path
        ///     m_file
        ///     m_backgroudMusicId
        /// 变量。
        ///
        /// 读取资源时，文件完整路径为m_fullPath，m_fullPath = m_path + "/" + m_file
        /// 
        /// m_backgroudMusicId未非必须初始化变量，不初始化时，没有背景音乐
        /// 
        /// m_root 此时为 null
        /// </summary>
        protected virtual void BeforeOpen()
        {
           
        }

        /// <summary>
        /// UI已经创建完毕，初始化游戏逻辑相关(m_root已经存在，只会调用一次)
        /// </summary>
        protected virtual void AftertOpen()
        {

        }

        /// <summary>
        /// 关闭UI时，释放资源，重写时，需要调用父类的Unint方法，以释放父类相关资源
        /// </summary>
        protected virtual void Uninit()
        {          
            UnregisterMsg();
           
            ResourceManager.GetInstance().UnloadUnusedAssets();
        }

        private void InitBackgroud()
        {
            if (m_containBackgroud && m_root != null)
            {
                string backgroudFile = "UIBackgroud";

                GameObject asset = Resources.Load<GameObject>(backgroudFile);

                if (asset)
                {                
                    GameObject instance = GameObject.Instantiate(asset);

                    instance.transform.parent = m_root;

                    RectTransform rectTransform = instance.GetComponent<RectTransform>();

                    rectTransform.sizeDelta = Tools.GetResolution();

                    rectTransform.pivot = Vector2.zero;

                    instance.name = backgroudFile;

                    instance.transform.localScale = Vector3.one;

                    instance.transform.SetAsFirstSibling();

                    if (m_clickBackgroud && instance != null)
                    {
                        UIEventListener listener = Tools.GetComponent<UIEventListener>(instance);

                        listener.onClick = Close;
                    }
                }
            }
        }

        /// <summary>
        /// 打开UI，供UIManager调用，逻辑层不能调用。
        /// </summary>
        public void Open()
        {
            if (m_root == null)
            {
                GameObject temp = GameObject.Find(m_file);
                if (temp != null)
                {
                    m_root = temp.transform;
                }

                if (m_root == null)
                {
                    if (m_path == "" || m_file == "")
                    {
                        Tools.AddError("The path is null or file is null.");
                    }
                    else
                    {
                        m_fullPath = m_path + "/" + m_file;

                        GameObject asset = ResourceManager.GetInstance().LoadAsset(m_fullPath);

                        if (asset != null)
                        {
                            m_root = GameObject.Instantiate(asset).transform;

                            m_root.gameObject.name = m_file;

                            if (m_backgroudMusicId > 0)
                            {
                                MusicManager.GetInstance().PlayMusic(m_backgroudMusicId);
                            }

                            InitBackgroud();

                            Display();

                            AftertOpen();
                        }
                    }
                }
                else
                {
                    Display();
                }
            }
            else
            {
                Display();
            } 
        }

        /// <summary>
        /// 关闭UI, 供UIManager调用，逻辑层不能调用。
        /// </summary>
        /// <param name="isDestroyRoot"> true：销毁创建的UI游戏对象。  false：隐藏UI游戏对象，不销毁</param>
        public void Close(bool isDestroyRoot = true)
        {
            if (isDestroyRoot && m_root != null)
            {
                GameObject.Destroy(m_root.gameObject);
              
                m_root = null;
                
                Uninit();                                 
            }
            else
            {
                Hide();
            }
        }
        
        /// <summary>
        /// 关闭UI, 供UIManager调用，逻辑层不能调用。
        /// </summary>
        /// <param name="uiEventData"></param>
        private void Close(PointerEventData uiEventData)
        {        
            UIManager.GetInstance().CloseUI(m_uiType);
        }

        /// <summary>
        /// 隐藏UI
        /// </summary>
        public void Hide()
        {
            if (m_root != null)
            {
                m_visible = false;

                m_root.gameObject.SetActive(false);
            }        
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        public void Display()
        {
            m_visible = true;

            m_root.gameObject.SetActive(true);
        }

        protected void RegisterMsg(Msg msgId, MsgCallback callback)
        {
            MsgManager.GetInstance().RegisterMsg(msgId, callback);

            m_registeredMsgIds.Add(msgId, callback);
        }

        protected void UnregisterMsg()
        {
            foreach (var item in m_registeredMsgIds)
            {
                if (item.Value != null)
                {
                    MsgManager.GetInstance().UnRegisterCallback(item.Key, item.Value);
                }
                else
                {
                    MsgManager.GetInstance().UnRegisterMsg(item.Key);
                }
            }
            m_registeredMsgIds.Clear();
        }

        protected bool RegisterUIEvent(string gameObjectName, UIEventHandlePointerEventData handlerData, UIEventHandleVector2 handlerV2 = null,UIEventType type = UIEventType.onClick)
        {
            bool registered = false;

            if (m_root != null)
            {
                Transform btn = m_root.Find(gameObjectName);
              
                if (btn != null)
                {
                    registered = true;

                    switch (type)
                    {
                        case UIEventType.onClick:
                           
                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onClick += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onClickUp:
                            
                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onClickUp += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }
                          
                            break;
                        case UIEventType.onClickDown:
                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onClickDown += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onBeginDrag:

                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onBeginDrag += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onDrag:

                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onDrag += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onEndDrag:

                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onEndDrag += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onDrop:

                            if (handlerData != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onDrop += handlerData;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerData is null");
                            }

                            break;
                        case UIEventType.onScroll:

                            if (handlerV2 != null)
                            {
                                Tools.GetComponent<UIEventListener>(btn.gameObject).onScroll += handlerV2;
                            }
                            else
                            {
                                Tools.AddWarming("RegisterUIEvent:handlerV2 is null");
                            }

                            break;
                        default:
                            break;
                    }               
                }
                else
                {
                    Tools.AddWarming("RegisterUIEvent:Can't find GameObject[" + gameObjectName + "]");
                }
            }
            else 
            {
                Tools.AddWarming("RegisterUIEvent error: m_root is null");
            }
            return registered;
        }

        protected bool IsVisible()
        {
            return m_visible;
        }
    }
}