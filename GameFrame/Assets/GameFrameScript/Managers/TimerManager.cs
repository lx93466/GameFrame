using UnityEngine;
using System.Collections.Generic;
using System;

namespace GameFrame
{
    /// <summary>
    /// 定时器管理类
    /// </summary>
    public class TimerManager : Singleton<TimerManager>
    {
        Dictionary<int, Timer> m_timers = new Dictionary<int, Timer>();//<TimerID, Timer>

        int m_curTimerId = 1;

        public void Schedule(TimerCallback callback, int timerID = 0, float intervalTime = 1.0f, float delayTime = 0.0f, bool loop = true)
        {
            if (callback != null)
            {
                Timer timer = Timer.CreateTimer();

                if (timerID == 0)
                {
                    timerID = GetTimerID();
                }

                timer.Register(callback, timerID, intervalTime, delayTime, loop);

                m_timers.Add(timerID, timer);    
            }
        }

        /// <summary>
        /// 延迟调用
        /// </summary>
        /// <param name="callback">调用函数</param>
        /// <param name="delayTime">延迟时间：0 下一帧调用;  1 延迟 delayTime调用.</param>
        public void DelayCall(DelayCallback callback, float delayTime = 0f)
        {
            DelayCallTarget delayCall = DelayCallTarget.AddDelayCall();

            delayCall.Register(callback, delayTime);
        }

        public bool Unschedule(int timerID)
        {
            bool ret = false;

            Timer timer = null;

            if (m_timers.TryGetValue(timerID, out timer))
            {
                timer.UnregisterTimer();

                m_timers.Remove(timerID);

                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public int GetTimerID()
        {
            return m_curTimerId ++;
        }

    }
}

