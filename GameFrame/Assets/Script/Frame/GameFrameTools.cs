﻿using UnityEngine;
using System;

namespace GameFrame
{
    class Tools
    {
        public static int msgId = 0;

        public static string GetAppDir()
        {
            string dir = Application.streamingAssetsPath;
            return dir + "/";
        }

        public static void AddWarming(string warming)
        {
            Debug.LogWarning(warming);
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
        
        public static int GetMsgId()
        {
            return 0;
        }

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
    }
}
