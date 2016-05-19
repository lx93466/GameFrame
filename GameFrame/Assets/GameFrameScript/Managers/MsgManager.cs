using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace GameFrame
{
    public class Msg
    {
        public int msgId = 0;

        public Hashtable Hashtable = null;

        public string msgName = "";

        public Msg(string name = "")
        {
            msgName = name;
            msgId++;
        }
    }

    public delegate void MsgCallback(Hashtable args);   
   
    class MsgManager : Singleton<MsgManager>
    {   
        Dictionary<Msg, MsgCallback> m_msgDictionary = new Dictionary<Msg, MsgCallback>();

        public bool RegisterMsg(Msg msgId, MsgCallback callback)
        {
            bool registered = false;
            
            if (msgId != null && callback != null)
            {
                MsgCallback tempMsg = null;
                if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
                {
                    //tempMsg += callback; //值传递，不能添加委托
                    m_msgDictionary[msgId] += callback;//引用传递，能添加委托
                }
                else
                {
                    m_msgDictionary.Add(msgId, callback);
                }
                registered = true;
            }
            else
            {
                Tools.AddError("RegisterMsg: msgId is null or callback is null");
            }
            return registered;
        }

        public bool UnRegisterMsg(Msg msgId)
        {
            bool registerResult = true;

            if (msgId != null)
            {
                MsgCallback tempMsg = null;

                if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
                {
                    m_msgDictionary.Remove(msgId);
                    registerResult = true;
                }
                else
                {
                    Tools.AddWarming("UnRegisterMsg:要注销的消息不存在。");
                    registerResult = false;
                }
            }
            else
            {
                Tools.AddError("UnRegisterMsg: msgId is null");
            }
           

            return registerResult;
        }
       
        public bool UnRegisterCallback(Msg msgId, MsgCallback callback)
        {
            bool registerResult = true;

            if (msgId != null && callback != null)
            {
                MsgCallback tempMsg = null;
             
                if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)           
                {
                    m_msgDictionary[msgId] -= callback;//引用传递，能添加委托

                    if (m_msgDictionary[msgId] == null)
                    {
                        UnRegisterMsg(msgId);
                    }                                    
                }
                else
                {
                    Tools.AddWarming("UnRegisterCallback:要注销的回调消息不存在。");
                    registerResult = false;
                }
            }
            else
            {
                Tools.AddError("RegisterMsg: msgId is null or callback is null");
            }           
            return registerResult;
        }

        public bool DispatchMsg(Msg msgId, Hashtable args = null)
        {
            bool dispachResult = true;

            if (msgId != null)
            {
                MsgCallback tempMsg = null;
                if (m_msgDictionary.TryGetValue(msgId, out tempMsg) == true)
                {
                    if (tempMsg != null)
                    {
                        tempMsg(args);
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
            }
            else
            {
                Tools.AddError("DispatchMsg: msgId is null");                
            }                    
           return dispachResult;
        }      
    }
}
