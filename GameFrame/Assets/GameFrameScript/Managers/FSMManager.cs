﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public enum FSMRunState
    {
        None,
        Initialized,//初始化完毕
        Executing,//执行中
        End//状态执行结束
    }

    public delegate void StateExecuteDelegate(Hashtable args);
    /// <summary>
    /// 只是单纯的状态，任何状态之间都可以切换，没有状态与状态之间的关联控制
    /// </summary>
    public class FSMState
    {
        public FSMStateId m_stateId = null;

        public bool m_break = true; // 状态在执行过程中，是否可以被打断

        public float m_stateTime = 0; //状态执行时间
        //状态执行主体
        public StateExecuteDelegate m_executeDalegate = null;
        //固定刷新(20fps)
        public TimerCallback m_fixedUpdateDalegate = null;

        public FSMRunState m_runState = FSMRunState.None;

        public FSMManager m_fsmControlManager = null;

        public FSMState m_nextState = null;

        int m_executeTimerId = TimerManager.GetInstance().GetTimerID();
        int m_fixedUpdateTimerId = TimerManager.GetInstance().GetTimerID();

        public FSMState()
        {
            Init();
            m_runState = FSMRunState.Initialized;
        }

        public void Execute(Hashtable args)
        {
            m_runState = FSMRunState.Executing;
           
            if (m_executeDalegate != null)
            {
                m_executeDalegate(args);
            }
            if (m_fixedUpdateDalegate != null)
            {
                TimerManager.GetInstance().Schedule(m_fixedUpdateDalegate, m_fixedUpdateTimerId, 0.05f);
            }

            if (m_stateTime < 0.0001)//执行时间小于0
            {
                EndExecuteCallback();
            }
            else
            {
                TimerManager.GetInstance().Schedule(EndExecuteCallback, m_executeTimerId, m_stateTime, m_stateTime, false);
            }
        }

        void EndExecuteCallback()
        {
            TimerManager.GetInstance().Unschedule(m_executeTimerId);
            TimerManager.GetInstance().Unschedule(m_fixedUpdateTimerId);
            EndOfExecute();
            m_runState = FSMRunState.End;
        }

        //状态初始化
        protected virtual void Init(){}

        public virtual void PreChangeToNextState() { }
        protected virtual void EndOfExecute() { }

        //结束动画状态
        public virtual void ForceExit() 
        {
            TimerManager.GetInstance().Unschedule(m_executeTimerId);
            TimerManager.GetInstance().Unschedule(m_fixedUpdateTimerId);
            EndOfExecute();
            m_runState = FSMRunState.End;
            m_nextState = null;
        }
    }

    public class FSMManager
    {
        Dictionary<FSMStateId, FSMState> m_states = new Dictionary<FSMStateId, FSMState>();

        public FSMState m_curState = null;

        public FSMState m_changeState = null;
        public void AddState(FSMState state)
        {
            if (state != null && state.m_stateId != null)
            {
                FSMState tempState = null;

                if (!m_states.TryGetValue(state.m_stateId, out tempState))
                {
                    state.m_fsmControlManager = this;
                    m_states.Add(state.m_stateId, state);
                }
            }
        }

        public void DeleteState(FSMStateId stateId)
        {
            if (stateId != null)
            {
                m_states.Remove(stateId);
            }
        }

        void ExecuteState(FSMStateId stateId, Hashtable args = null)
        {
            if (m_changeState == null) return;
            
            if (m_changeState.m_runState == FSMRunState.Executing && m_changeState.m_break == false)
            {
                //Tools.AddLog("被切换状态正在执行，不能被打断");
            }
            else if(m_changeState.m_runState == FSMRunState.Executing && m_changeState.m_break == true)
            {
                m_changeState.ForceExit();
                m_changeState.Execute(args);
                m_curState = m_changeState;
            }
            else
            {
                m_changeState.Execute(args);
                m_curState = m_changeState;
            }
        }

        public void ChangeState(FSMStateId stateId, Hashtable args = null)
        {
            if (m_states.TryGetValue(stateId, out m_changeState))
            {
                if (m_curState != null)
                {
                    m_curState.m_nextState = m_changeState;

                    m_curState.PreChangeToNextState();
                    if (m_curState.m_runState == FSMRunState.Executing && m_curState.m_break == false)
                    {
                        //Tools.AddLog("当前状态正在执行，不能被打断");
                    }
                    else if (m_curState.m_runState == FSMRunState.Executing && m_curState.m_break == true)
                    {
                        m_curState.ForceExit();
                        ExecuteState(stateId, args);
                    }
                    else
                    {
                        ExecuteState(stateId, args);
                    }

                }
                else
                {
                    ExecuteState(stateId, args);
                }
            }
        }

        public void ForceEndState(FSMStateId stateId)
        {
            FSMState state = null;
            if (m_states.TryGetValue(stateId, out state))
            {
                state.ForceExit();
            }
        }
    }
}

