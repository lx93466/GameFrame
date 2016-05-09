using UnityEngine;
using System.Collections;

namespace GameFrame
{
    public delegate void DelayCallback();

    class DelayCallTarget : MonoBehaviour
    {
        DelayCallback m_delayCallback = null;

        float m_delayTime = 0f;

        public static DelayCallTarget AddDelayCall()
        {
            DelayCallTarget delayCall = null;

            GameObject obj = Tools.CreatEmptyGameObject("DelayCallTarget");

            if (obj != null)
            {

                delayCall = obj.AddComponent<DelayCallTarget>();
            }

            return delayCall;
        }

        public void Register(DelayCallback callback, float delayTime)
        {
            m_delayCallback = callback;

            m_delayTime = delayTime;
        }

        IEnumerator call()
        {
            if (m_delayTime <= 0)
            {
                yield return 0;
            }
            else
            {
                yield return new WaitForSeconds(m_delayTime);
            }

            if (m_delayCallback != null)
            {
                m_delayCallback();

                GameObject.Destroy(this);
            }
        }

        void Start()
        {
            if (m_delayCallback != null)
            {
                DontDestroyOnLoad(this);
                StartCoroutine(call());                
            }
        }
    }
}

