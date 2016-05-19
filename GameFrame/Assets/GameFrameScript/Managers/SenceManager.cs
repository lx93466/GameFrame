using System.Collections.Generic;
using UnityEngine;


namespace GameFrame
{
    public delegate SceneBase GetSeceneInstanceDelegate();
   
    class GameSceneManager : Singleton<GameSceneManager>
    {
        private Dictionary<SceneType, GetSeceneInstanceDelegate> m_SceneDelegates = new Dictionary<SceneType, GetSeceneInstanceDelegate>();//<注册的UI类型, 获取注册UI实例的方法>
       
        
        //要使用的Scene，必须注册
        public void RegisterScene(SceneType sceneType, GetSeceneInstanceDelegate uiDelegate)
        {
            GetSeceneInstanceDelegate tempDelegate = null;

            if (!m_SceneDelegates.TryGetValue(sceneType, out tempDelegate))
            {
                uiDelegate().m_SceneType = sceneType;

                m_SceneDelegates.Add(sceneType, uiDelegate);
            }
        }

        public void OpenScene(SceneType sceneType, bool isAsync = false)
        {
            GetSeceneInstanceDelegate sceneDelegate = null;

            if (m_SceneDelegates.TryGetValue(sceneType, out sceneDelegate))
            {
                if (isAsync)
                {
                    sceneDelegate().OpenAsync();
                }
                else
                {
                    sceneDelegate().Open();
                }
            }
            else
            {
                Tools.AddWarming("You are not Registered Scene:" + sceneType.ToString());
            }
        }
    }
}
