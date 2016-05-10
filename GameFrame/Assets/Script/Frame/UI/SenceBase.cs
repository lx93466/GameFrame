using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFrame
{
    public class SceneBase
    {
        protected string m_scenePath = "";//文件所在路径

        public string m_sceneFile = "";//文件名称

        public UIType m_mainUIType = UIType.None;//打开Scene时，同时打开的UI界面

        public SceneType m_SceneType = SceneType.None;

        public LoadSceneMode m_loadSceneMode = LoadSceneMode.Single;

        public SceneBase()
        {
            BeforeOpen();
        }

        protected virtual void BeforeOpen()
        {
            MsgManager.GetInstance().DispatchMsg(UIManagerMsgDefine.ClearOpenedUIMsg);
        }

        protected virtual void AfterOpen()
        {

        }

        public void OpenAsync()
        {
            
        }

        public void OpenUI()
        {
            if (m_mainUIType != UIType.None)
            {
                UIManager.GetInstance().OpenUI(m_mainUIType);
            }
        }

        public void Open()
        {
            Tools.AddTip("Load Scene:" + m_scenePath + "/" + m_sceneFile);

            SceneManager.LoadScene(m_scenePath + "/" + m_sceneFile, m_loadSceneMode);

            // 直接在此处动态创建对象时，属于上一个场景。因为此帧还属于上一场景的帧。
            TimerManager.GetInstance().DelayCall(OpenUI);

            AfterOpen();
        }
    }

}
