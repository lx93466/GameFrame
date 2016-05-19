using UnityEngine;
using System.Collections.Generic;

namespace GameFrame
{
    public class GameBehaviour : MonoBehaviour 
    {
        Dictionary<Msg, MsgCallback> m_registeredMsg = new Dictionary<Msg, MsgCallback>();	   

        protected void RegisterMsg(Msg msgId, MsgCallback callback)
        {
            if (MsgManager.GetInstance().RegisterMsg(msgId, callback))
            {
                m_registeredMsg.Add(msgId, callback);
            }
        }

        protected virtual void Init() { }

        protected virtual void Uninit()
        {
            foreach (var msg in m_registeredMsg)
            {
                MsgManager.GetInstance().UnRegisterCallback(msg.Key, msg.Value);
            }
        }

        void Awake()
        {
            Init();
        }

        void OnDestroy()
        {
            Uninit();
        }
    }
}

