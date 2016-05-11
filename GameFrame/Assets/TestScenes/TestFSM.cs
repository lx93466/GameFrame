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
    public override void Enter()
    {
        Debug.Log("State1.Enter()");
    }

    public override void Exit()
    {
        Debug.Log("State1.Exit()");
    }

    public override void Init()
    {
        m_stateId = TestStateIdDefine.state1;
    }
}

class State2 : FSMState
{
    public override void Enter()
    {
        m_stateId = TestStateIdDefine.state2;

        Debug.Log("State2.Enter()");
    }

    public override void Exit()
    {
        Debug.Log("State2.Exit()");
    }

    public override void Init()
    {
        m_stateId = TestStateIdDefine.state2;
    }
}

class State3 : FSMState
{
    public override void Enter()
    {
        m_stateId = TestStateIdDefine.state3;

        Debug.Log("State3.Enter()");
    }

    public override void Exit()
    {
        Debug.Log("State3.Exit()");
    }

    public override void Init()
    {
        m_stateId = TestStateIdDefine.state3;
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
