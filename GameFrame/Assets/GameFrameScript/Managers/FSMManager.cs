using System.Collections.Generic;

namespace GameFrame
{
    public class FSMStateId
    {
        public string m_stateName = "";

        public FSMStateId(string name = "none")
        {
            m_stateName = name;
        }
    }

    public enum State
    {
        None,
        Initialized,//初始化完毕
        Executing,//执行中
        End//状态执行结束
    }

    public delegate void StateExecuteDelegate();
    /// <summary>
    /// 只是单纯的状态，任何状态之间都可以切换，没有状态与状态之间的关联控制
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateId m_stateId = null;

        public bool m_break = true; // 状态在执行过程中，是否可以被打断

        public float m_stateTime = 0; //状态执行时间
        //状态执行主体
        public StateExecuteDelegate m_executeDalegate = null;

        public State m_state = State.None;

        public FSMState()
        {
            Init();
            m_state = State.Initialized;
        }
        //状态初始化
        public abstract void Init();

        public void Execute()
        {
            m_state = State.Executing;
           
            if (m_executeDalegate!= null)
            {
                m_executeDalegate();                     
            }

            TimerManager.GetInstance().DelayCall(EndExecute, m_stateTime);
        }

        protected void EndExecute()
        {
            m_state = State.End;
            Exit();
        }

        //执行结束
        public virtual void Exit() { }

    }

    public class FSMManager
    {
        Dictionary<FSMStateId, FSMState> m_states = new Dictionary<FSMStateId, FSMState>();

        FSMState m_curState = null;

        public void AddState(FSMState state)
        {
            if (state != null && state.m_stateId != null)
            {
                FSMState tempState = null;

                if (!m_states.TryGetValue(state.m_stateId, out tempState))
                {
                    m_states.Add(state.m_stateId, state);
                }
                else
                {
                    Tools.AddError("AddState: Adding state is existed.");
                }
            }
            else
            {
                Tools.AddError("AddState: Adding state is null or state.m_stateId is null.");
            }
        }

        public void DeleteState(FSMStateId stateId)
        {
            if (stateId != null)
            {
                m_states.Remove(stateId);
            }
        }

        public void ChangeState(FSMStateId stateId)
        {
            if (m_curState != null)
            {
                if (m_curState.m_state == State.Executing && m_curState.m_break == false)
                {
                    Tools.AddLog("当前状态[" + m_curState.m_stateId.m_stateName + "]正在执行，并且不可被打断");
                }
                else
                {
                    FSMState changeState = null;

                    if (m_states.TryGetValue(stateId, out changeState))
                    {
                        if (changeState.m_state == State.Executing && changeState.m_break == false)
                        {
                            Tools.AddLog("切换状态时，新切换的状态[" + changeState.m_stateId.m_stateName + "]正在执行，并且不可被打断");
                        }
                        else
                        {
                            Tools.AddLog("切换状态：从" + m_curState.m_stateId.m_stateName + "切换到" + changeState.m_stateId.m_stateName);
                           
                            changeState.Execute();
                           
                            m_curState = changeState;
                        }
                    }
                }
            }
            else
            {
                 FSMState changeState = null;

                if (m_states.TryGetValue(stateId, out changeState))
                {
                    if (changeState.m_state == State.Executing && changeState.m_break == false)
                    {
                        Tools.AddLog("切换状态时，新切换的状态[" + changeState.m_stateId.m_stateName + "]正在执行，并且不可被打断");
                    }
                    else
                    {
                        changeState.Execute();

                        m_curState = changeState;
                       
                        Tools.AddLog("切换状态：从无状态切换到" + changeState.m_stateId.m_stateName);
                    }
                }
            }
        }
    }
}

