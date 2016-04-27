using GameFrame;
using System.Collections;
using System.Collections.Generic;

namespace GameFrame
{
    class TestConfig : ConfigDataBaseClass
    {
        public class TestConfigData
        {
            public string m_name;

            public string m_sex;

            public int m_age;

            public TestConfigData()
            {
                m_name = "";

                m_sex = "";

                m_age = 0;
            }
        }

        List<TestConfigData> m_testConfigs = new List<TestConfigData>();

        public List<TestConfigData> GetAllConfigData()
        {
            return m_testConfigs;
        }

        public static TestConfig GetInstance()
        {
            return Singleton<TestConfig>.GetInstance();
        }

        #region 重写父类读取数据方法
        public override void Init()
        {
            m_configFileName = "Config/testConfig.xlsx";
        }

        public override void ReadConfig()
        {
            for (int i = 0; i < m_rows; ++ i)
            {
                TestConfigData config = new TestConfigData();
                
                config.m_name = GetValue(i, 0);
                config.m_sex = GetValue(i, 1);
                config.m_age = Tools.ToInt(GetValue(i, 2));

                m_testConfigs.Add(config);
            }
        }       

        public override void UnInit()
        {
            m_configFileName = "";
            m_testConfigs.Clear();
        }
        #endregion
    }
}

