using GameFrame;
using System.Collections;
using System.Collections.Generic;

class TestConfigData
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

class TestConfig : ConfigDataBaseClass
{
    public ArrayList GetAllConfigData()
    {
        return m_configData;
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
        for (int i = 1; i < m_rows; ++ i)
        {
            TestConfigData config = new TestConfigData();
                
            config.m_name = GetValue(i, 0);
            config.m_sex = GetValue(i, 1);
            config.m_age = Tools.ToInt(GetValue(i, 2));

            m_configData.Add(config);
        }
    }       
    #endregion
}


