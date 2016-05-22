using UnityEngine;
using System;

namespace GameFrame
{
    public class Tools
    {
        public static int msgId = 0;

        public static string GetAppDir()
        {
            string dir = Application.streamingAssetsPath;
            return dir + "/";
        }

        public static void AddWarming(string warming)
        {
            if (warming != null)
            {
                Debug.LogWarning(warming);
            }         
        }

        public static void AddLog(string Tip)
        {
            if (Tip != null)
            {
                Debug.Log(Tip);
            }
        }

        public static void AddError(string error)
        {
            if (error != null)
            {
                Debug.LogError(error);
            }           
        }

        #region  常用数据转换接口
        public static int ToInt(string value)
        {
            return int.Parse(value);
        }

        public static float ToFloat(string value)
        {
            return float.Parse(value);
        }

        public static string ToString(int value)
        {
            return value.ToString();
        }

        public static string ToString(float value)
        {
            return value.ToString();         
        }
        #endregion
        
       
        public static T GetComponent<T>(GameObject gameObject) where T : MonoBehaviour
        {
            T t = null;

            if (gameObject != null)
            {
                t = gameObject.GetComponent<T>();

                if (t == null)
                {
                    t = gameObject.AddComponent<T>();
                }
            }
            
            return t;
        }

        public static void AddComponent<T>(GameObject gameObject) where T : MonoBehaviour
        {
            GetComponent<T>(gameObject);
        }
       /// <summary>
       /// 给动画添加事件
       /// </summary>
       /// <param name="animator">动画实例</param>
       /// <param name="motionName">状态机对应motion名称</param>
       /// <param name="fnName">事件调用函数名称</param>
       /// <param name="triggerTime">事件触发时间：triggerTime < 0 | triggerTime > 动画播放最长时间 时，事件添加在动画播放结束时</param>
       /// <param name="args">事件触发时的参数</param>
        public static void AddAnimatorEvent(Animator animator, string motionName, string fnName, float triggerTime = -1f, string args = "")
        {
            if (animator != null && motionName != null && motionName.Length > 0 && fnName != null && fnName.Length > 0)
            {

                AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

                for (int i = 0; i < clips.Length; i++)
                {                  
                    AnimationClip clip = clips[i];
                    if (clip.name == motionName)
                    {
                        //计算事件触发时间
                        if (triggerTime < 0 || triggerTime > clip.length)
                        {
                            triggerTime = clip.length;
                        }

                        //判断待添加事件是否已经存在，若存在，则不重复添加
                        AnimationEvent[] existedEvents = clip.events;
                        for (int j = 0; j < existedEvents.Length; j++)
                        {
                            AnimationEvent existedEvent = existedEvents[j];
                            if (existedEvent.functionName == fnName && existedEvent.time == triggerTime)
                            {
                                return;
                            }
                        }
                        //添加事件
                        AnimationEvent animationEvent = new AnimationEvent();
                        animationEvent.functionName = fnName;
                        animationEvent.time = triggerTime;
                        clip.AddEvent(animationEvent);
                    }
                }
            }
        }
        /// <summary>
        /// 锁屏、解锁屏
        /// </summary>
        public static void LockScreen()
        {
            GameObject instance = GameObject.Find("LockScreenCanvas");
            if (instance == null)
            {
                GameObject go = Resources.Load<GameObject>("LockScreenCanvas");
                if (go != null)
                {
                    instance = GameObject.Instantiate(go);
                    instance.name = "LockScreenCanvas";
                }
                else
                {
                    Tools.AddWarming("Lock Screen Failed.");
                }
            }
        }
    
        public static void UnlockScreen()
        {
            GameObject instance = GameObject.Find("LockScreenCanvas");
            if (instance != null)
            {
                GameObject.Destroy(instance);
            }
        }

        /// <summary>
        /// 创建空游戏物体
        /// </summary>
        public static GameObject CreatEmptyGameObject(string name = "EmptyObject")
        {
            GameObject go = Resources.Load<GameObject>("EmptyObject");

            GameObject instance = null;
            if (go != null)
            {
                instance = GameObject.Instantiate(go);
                instance.name = name;
            }
            return instance;
        }

        public static Vector2 GetResolution()
        {
            return new Vector2(1280, 720);
        }
    }

    public class Singleton<T> where T : class,new()
    {
        private static T m_instance;

        protected Singleton()
        {
            if (m_instance != null)
            {
                throw new Exception("单例对象已经存在，继承单例的类不能new，否则后果未知。");
            }
        }

        public static T GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new T();

            }
            return m_instance;
        }

        public virtual void Init() { }
    }
}
