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
            if (warming.Length != 0)
            {
                Debug.LogWarning(warming);
            }         
        }

        public static void AddTip(string Tip)
        {
            if (Tip.Length != 0)
            {
                Debug.Log(Tip);
            }
        }

        public static void AddError(string error)
        {
            if (error.Length != 0)
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
            if (go != null)
            {
                GameObject instance = GameObject.Instantiate(go);
                instance.name = name;
            }
            return go;
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
