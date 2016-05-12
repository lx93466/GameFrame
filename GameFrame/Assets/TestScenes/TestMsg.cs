using UnityEngine;
using System.Collections;
using GameFrame;

class TestMsgDefine
{
    public static Msg testMsgid = new Msg();
}

public class TestMsg : MonoBehaviour {
    public void Dispach()
    {
         Hashtable hash = new Hashtable();
        hash.Add(1, "string1");
        hash.Add("ssss", gameObject);

        MsgManager.GetInstance().DispatchMsg(TestMsgDefine.testMsgid);                   
    }

    public void Rigister(int i)
    {
        if (i == 1)
        {
            MsgManager.GetInstance().RegisterMsg(TestMsgDefine.testMsgid, MsgCallback1);            
        }
        else if (i == 2)
        {
            MsgManager.GetInstance().RegisterMsg(TestMsgDefine.testMsgid, MsgCallback2);            
        }
    }

    public void UnRigister(int i)
    {
        if (i == 1)
        {
            MsgManager.GetInstance().UnRegisterCallback(TestMsgDefine.testMsgid, MsgCallback1);
        }
        else if (i == 2)
        {
            MsgManager.GetInstance().UnRegisterCallback(TestMsgDefine.testMsgid, MsgCallback2);
        }
    }
   
    public void UnRigisterAll()
    {
        MsgManager.GetInstance().UnRegisterMsg(TestMsgDefine.testMsgid);
    }

    void MsgCallback1(MsgArg args)
    {
        Debug.Log("MsgCallback1");
        //if (args != null)
        //{
        //    foreach (var key in args.Keys)
        //    {
        //        Debug.Log("(key, value) = (" + key + "," + args[key] + ")");
        //    }
        //}
    }

    void MsgCallback2(MsgArg args)
    {
        Debug.Log("MsgCallback2");
        //if (args != null)
        //{
        //    foreach (var key in args.Keys)
        //    {
        //        Debug.Log("(key, value) = (" + key + "," + args[key] + ")");
        //    }
        //}
    }
}
