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
    /// <summary>
    /// 只是单纯的状态，任何状态之间都可以切换，没有状态与状态之间的关联控制
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateId m_stateId = null;

        public FSMState()
        {
            Init();
        }

        public abstract void Init();

        public abstract void Enter();

        public virtual void Exit() { }

        //每帧刷新
        public virtual void Update() { }
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
            if (stateId != null)
            {
                if (m_curState != null)
                {
                    Tools.AddLog("Changed state from " + m_curState.m_stateId.m_stateName + " to " + stateId.m_stateName);
                }
                else
                {
                    Tools.AddLog("Changed state from no state to " + stateId.m_stateName);
                }

                FSMState changeState = null;

                if (m_states.TryGetValue(stateId, out changeState))
                {
                    if (m_curState != null)
                    {
                        m_curState.Exit();
                    }

                    changeState.Enter();

                    m_curState = changeState;                    
                }
                else
                {
                    Tools.AddError("ChangeState: Adding state is not existed.");
                }
            }
            else
            {
                Tools.AddError("ChangeState: State id is null.");
            }
        }
    }
}

