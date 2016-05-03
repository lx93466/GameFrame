using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace GameFrame
{
    /// <summary>
    /// 一个UI必须是一个画布：Canvas
    /// </summary>
    abstract class LayerBase
    {
        protected Transform m_root = null;
        
        private bool m_visible = false;

        private string m_path = "";//文件所在路径

        private string m_file = "";//文件名称

        private int m_backgroudMusicId = -1;

        private string m_fullPath = "";

        private bool m_containBackgroud = true; //是否包含半透明背景

        private bool m_clickBackgroud = true;  // 半透明背景是否可点击关闭

        private Dictionary<MsgId, MsgCallback> m_registeredMsgIds;

        /// <summary>
        /// 重写此函数，初始化
        ///     m_path
        ///     m_file
        ///     m_backgroudMusicId
        /// 变量。
        /// 重写时，要调用父类重写的方法。
        /// 读取资源时，文件完整路径为m_fullPath，m_fullPath = m_path + "/" + m_file
        /// 
        /// m_backgroudMusicId未非必须初始化变量，不初始化时，没有背景音乐
        /// </summary>
        protected virtual void Init()
        {
            if (m_containBackgroud)
            {
                string backgroudFile = "LayerBackgroud";

                GameObject asset = Resources.Load<GameObject>(backgroudFile);
                
                if (asset)
                {
                    GameObject instance = GameObject.Instantiate(asset);
                
                    instance.transform.parent = m_root;

                    instance.name = backgroudFile;

                    if (m_clickBackgroud && instance != null)
                    {
                        UIEventListener listener = Tools.GetComponent<UIEventListener>(instance);

                        listener.onClick = Close;
                    }
                }
            }
        }

        protected virtual void Uninit()
        {
            m_visible = false;

            m_path = "";

            m_file = "";

            m_backgroudMusicId = -1;

            m_fullPath = "";

            UnregisterMsg();
        }

        /// <summary>
        /// 显示Layer
        /// </summary>
        public void Show()
        {
            if (m_root == null)
            {
                GameObject temp = GameObject.Find(m_file);
                if (temp != null)
                {
                    m_root = temp.transform;
                }

                if (m_root)
                {
                    Init();

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
        /// 关闭Layer。
        /// 
        /// isDestroyRoot：
        ///     true：销毁创建的Layer游戏对象。
        ///     false：隐藏Layer游戏对象，不销毁
        /// </summary>
        /// <param name="isDestroyRoot"></param>
        public void Close(bool isDestroyRoot = true)
        {
            if (isDestroyRoot)
            {
                Uninit();

                GameObject.Destroy(m_root.gameObject);
            }
            else
            {
                Hide();
            }
        }

        public void Close(PointerEventData uiEventData)
        {
            Close();
        }

        /// <summary>
        /// 隐藏Layer
        /// </summary>
        public void Hide()
        {
            m_visible = false;

            m_root.gameObject.SetActive(false);
        }

        /// <summary>
        /// 显示Layer
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
        }
    }
}