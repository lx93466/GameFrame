using UnityEngine;
using System.Collections;
using GameFrame;
public class TestMsg : MonoBehaviour {
    public void Dispach()
    {
         Hashtable hash = new Hashtable();
        hash.Add(1, "string1");
        hash.Add("ssss", gameObject);
       
        MsgManager.GetInstance().DispatchMsg(MsgId.testMsgId, hash);                   
    }

    public void Rigister(int i)
    {
        if (i == 1)
        {
            MsgManager.GetInstance().RegisterMsg(MsgId.testMsgId, MsgCallback1);            
        }
        else if (i == 2)
        {
            MsgManager.GetInstance().RegisterMsg(MsgId.testMsgId, MsgCallback2);            
        }
    }

    public void UnRigister(int i)
    {
        if (i == 1)
        {
            MsgManager.GetInstance().UnRegisterCallback(MsgId.testMsgId, MsgCallback1);
        }
        else if (i == 2)
        {
            MsgManager.GetInstance().UnRegisterCallback(MsgId.testMsgId, MsgCallback2);
        }
    }
   
    public void UnRigisterAll()
    {
        MsgManager.GetInstance().UnRegisterMsg(MsgId.testMsgId);
    }

    void MsgCallback1(Hashtable args)
    {
        Debug.Log("MsgCallback1");
        if (args != null)
        {
            foreach (var key in args.Keys)
            {
                Debug.Log("(key, value) = (" + key + "," + args[key] + ")");
            }
        }
    }

    void MsgCallback2(Hashtable args)
    {
        Debug.Log("MsgCallback2");
        if (args != null)
        {
            foreach (var key in args.Keys)
            {
                Debug.Log("(key, value) = (" + key + "," + args[key] + ")");
            }
        }
    }
}
