using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GameFrame
{
    /// <summary>
    /// 消息类型
    /// </summary>
    enum MsgType
    {
        deletable = 4534534,    //可删除的消息,即既可注册，又可删除
        undeletable             //不可删除的消息，即一直存在于消息管理器中
    }

    public delegate void MsgCallback(Hashtable args);   
   
    class MsgManager : Singleton<MsgManager>
    {
        class Msg
        {

            public MsgId m_msgId;

            public MsgType m_msgType = MsgType.deletable;

            public MsgCallback m_callbacks;

            public Msg(MsgId msgId, MsgCallback callback, MsgType msgType)
            {
                m_msgId = msgId;

                m_msgType = msgType;

                if (callback != null)
                {
                    m_callbacks += callback;
                }
            }
        }

        Dictionary<MsgId, Msg> m_msgDictionary = new Dictionary<MsgId, Msg>();

        public void RegisterMsg(MsgId msgId, MsgCallback callback, MsgType msgType = MsgType.deletable)
        {
            Msg tempMsg = null;

            if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
            {
                tempMsg.m_msgType = msgType;
               
                tempMsg.m_callbacks += callback;
            }
            else
            {
                tempMsg = new Msg(msgId, callback, msgType);
                m_msgDictionary.Add(tempMsg.m_msgId, tempMsg);
            }
        }

        public bool UnRegisterMsg(MsgId msgId)
        {
            bool registerResult = true;

            Msg tempMsg = null;

            if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
            {
               if(tempMsg.m_msgType == MsgType.undeletable)
               {
                   Tools.AddWarming("UnRegisterMsg:要注销的消息类型是不可删除的[m_msgType:MsgType.undeletable]。 ");
                   registerResult = false;
               }
               else
               {
                   m_msgDictionary.Remove(msgId);
                   registerResult = true;
               }
            }
            else
            {
                Tools.AddWarming("UnRegisterMsg:要注销的消息不存在。");
                registerResult = false;
            }

            return registerResult;
        }
       
        public bool UnRegisterCallback(MsgId msgId, MsgCallback callback)
        {
            bool registerResult = true;

            Msg tempMsg = null;

            if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
            {
                if (callback != null)
                {
                    tempMsg.m_callbacks -= callback;
                    
                    if (tempMsg.m_callbacks == null)
                    {
                        UnRegisterMsg(msgId);
                    }
                }
                else
                {
                    Tools.AddWarming("UnRegisterCallback:要注销的消息回调是为null ");
                }               
            }
            else
            {
                Tools.AddWarming("UnRegisterMsg:要注销的回调消息不存在。");
                registerResult = false;
            }

            return registerResult;
        }
        public bool DispatchMsg(MsgId msgId, Hashtable hashtable = null)
        {
            bool dispachResult = true;

            Msg tempMsg = null;

            if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
            {
                if (tempMsg.m_callbacks != null)
                {
                    tempMsg.m_callbacks(hashtable);                                  
                }
                else
                {
                    m_msgDictionary.Remove(msgId);

                    Tools.AddWarming("DispachMsg:要分发的消息回调不存在，已注销消息。");
                }
            }
            else
            {
                Tools.AddWarming("DispachMsg:要分发的消息不存在。");
                dispachResult = false;
            }
            
            return dispachResult;
        }      
    }
}
