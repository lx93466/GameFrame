using System;
using System.Collections.Generic;

namespace GameFrame
{
    class ConfigManager : Singleton<ConfigManager>
    {
        public void Init()
        {
            TestConfig.GetInstance().InitConfig();   
        }

        public void UnInit()
        {
            TestConfig.GetInstance().UnInit();
        }
    }
}
