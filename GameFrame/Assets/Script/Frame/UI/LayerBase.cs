using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

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
        
        private bool m_visible = false;

        protected string m_path = "";//文件所在路径

        protected string m_file = "";//文件名称

        protected int m_backgroudMusicId = -1;

        private string m_fullPath = "";

        protected bool m_containBackgroud = true; //是否包含半透明背景

        protected bool m_clickBackgroud = true;  // 半透明背景是否可点击关闭

        public bool m_closePreUI = true; //关闭此UI时，是否关闭前一个打开的UI。

        public bool m_closeAllPreUI = true; //关闭此UI时，是否关闭打开的所有UI。

        public bool m_unclosable = false; //此UI是永不可关闭的

        public UIType m_uiType;

        private Dictionary<MsgId, MsgCallback> m_registeredMsgIds = new Dictionary<MsgId,MsgCallback>();

        /// <summary>
        /// 重写此函数，初始化
        ///     m_path
        ///     m_file
        ///     m_backgroudMusicId
        /// 变量。
        ///
        /// 读取资源时，文件完整路径为m_fullPath，m_fullPath = m_path + "/" + m_file
        /// 
        /// m_backgroudMusicId未非必须初始化变量，不初始化时，没有背景音乐
        /// </summary>
        protected virtual void Init()
        {
           
        }

        /// <summary>
        /// 关闭UI时，释放资源，重写时，需要调用父类的Unint方法，以释放父类相关资源
        /// </summary>
        protected virtual void Uninit()
        {
            m_visible = false;

            m_path = "";

            m_file = "";

            m_backgroudMusicId = -1;

            m_fullPath = "";

            UnregisterMsg();
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
        /// 打开UI
        /// </summary>
        public void Open()
        {
            Init();
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
        /// 关闭UI。
        /// 
        /// isDestroyRoot：
        ///     true：销毁创建的UI游戏对象。
        ///     false：隐藏UI游戏对象，不销毁
        /// </summary>
        /// <param name="isDestroyRoot"></param>
        public void Close(bool isDestroyRoot = true)
        {
            Uninit();
            if (!m_unclosable)
            {
                if (isDestroyRoot)
                {
                    GameObject.Destroy(m_root.gameObject);
                }
                else
                {
                    Hide();
                }
            }         
        }

        public void Close(PointerEventData uiEventData)
        {
            Close(false);
        }

        /// <summary>
        /// 隐藏UI
        /// </summary>
        public void Hide()
        {
            m_visible = false;

            m_root.gameObject.SetActive(false);
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        public void Display()
        {
            m_visible = true;

            m_root.gameObject.SetActive(true);
        }

        protected void RegisterMsg(MsgId msgId, MsgCallback callback)
        {
            MsgManager.GetInstance().RegisterMsg(msgId, callback, MsgType.deletable);

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
    }
}