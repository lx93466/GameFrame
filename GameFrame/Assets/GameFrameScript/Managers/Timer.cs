using UnityEngine;
using System.Collections;

namespace GameFrame
{
    public delegate void TimerCallback();

    public class Timer : MonoBehaviour
    {
        private float m_delayTime = 0;

        private float m_intervalTime = 0;

        private TimerCallback m_callback = null;

        private float m_calcuTime = 0.0f;  //累计时间

        private float m_scheduleTime = 0.0f;

        private bool m_loop = true;

        private int m_timerID = 0;

        public static Timer CreateTimer()
        {
            Timer timer = null;

            GameObject obj = Tools.CreatEmptyGameObject("Timer");

            if (obj != null)
            {
                timer = obj.AddComponent<Timer>();            
            }
              
            return timer;
        }

        public void Register(TimerCallback callback, int timerID, float intervalTime = 1f, float delayTime = 0f, bool loop = true)
        {
            if (callback != null)
            {
               m_intervalTime = intervalTime;

               m_delayTime = delayTime;

               m_callback = callback;

               m_scheduleTime = m_delayTime;

               m_timerID = timerID;

               m_loop = loop;

               gameObject.name = "Timer[timer id: " + m_timerID + "]";
            }     
        }

        public void UnregisterTimer()
        {        
            GameObject.Destroy(gameObject);        
        }

        void Update()
        {
            if (m_callback != null)
            {
                if (m_calcuTime - m_scheduleTime >= 0f)
                {                 
                    m_callback();

                    m_calcuTime -= m_scheduleTime;

                    m_scheduleTime = m_intervalTime;

                    if (m_loop == false)
                    {
                        TimerManager.GetInstance().Unschedule(m_timerID);
                    }
                }

                m_calcuTime += Time.deltaTime;
            }          
        }
    }
}

