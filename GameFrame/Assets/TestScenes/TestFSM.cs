using UnityEngine;
using System.Collections;
using GameFrame;

class TestStateIdDefine
{
    public static FSMStateId state1 = new FSMStateId("state1");
  
    public static FSMStateId state2 = new FSMStateId("state2");
  
    public static FSMStateId state3 = new FSMStateId("state3");
}

class State1 : FSMState
{
    protected override void Init()
    {
        m_stateId = TestStateIdDefine.state1;
        m_executeDalegate = State1Execute;
        m_stateTime = 3;
        m_break = true;
    }
    protected override void EndOfExecute()
    {
        Debug.Log("State1 EndOfExecute");
    }
    void State1Execute()
    {
        Debug.Log("State1 Execute");
    }
}

class State2 : FSMState
{
    protected override void Init()
    {
        m_stateId = TestStateIdDefine.state2;
        m_executeDalegate = State2Execute;
        m_stateTime = 3;
        m_break = false;
    }
    protected override void EndOfExecute()
    {
        Debug.Log("State2 EndOfExecute");
    }
    void State2Execute()
    {
        Debug.Log("State2 Execute");
    }
}

class State3 : FSMState
{
    protected override void Init()
    {
        m_stateId = TestStateIdDefine.state3;
        m_executeDalegate = State3Execute;
        m_stateTime = 3;
        m_break = false;
    }
    protected override void EndOfExecute()
    {
        Debug.Log("State3 EndOfExecute");
    }
    void State3Execute()
    {
        Debug.Log("State3 Execute");
    }
}


public class TestFSM : MonoBehaviour {

    FSMManager fsmManager = new FSMManager();

	// Use this for initialization
	void Start () {
        
        fsmManager.AddState(new State1());
       
        fsmManager.AddState(new State2());
       
        fsmManager.AddState(new State3());	
	}

    public void clickState1()
    {
        fsmManager.ChangeState(TestStateIdDefine.state1);
    }

    public void clickState2()
    {
        fsmManager.ChangeState(TestStateIdDefine.state2);
    }

    public void clickState3()
    {
        fsmManager.ChangeState(TestStateIdDefine.state3);
    }
}
