using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFrame;

enum MusicCycleTag
{
    Recyclable = 0,
    Unrecyclable
}

enum MusicType
{
    BackgroudMusic,
    SpecialEffectMusic
}

enum CacheTag
{
    Cachable,
    Uncachable
}

class MusicConfigData
{
    public int m_index;

    public int m_primaryKey;

    public string m_fileName;

    public MusicCycleTag m_cycleTag;

    public MusicType m_musicType;

    public CacheTag m_cachable;
}

class MusicConfig : ConfigDataBaseClass
{
    public MusicConfigData GetMusicConfigByPrimaryKey(int key)
    {
        MusicConfigData configData = null;
       
        MusicConfigData temp = null;

        foreach (var config in m_configData)
        {
            temp = config as MusicConfigData;
            if (temp != null && temp.m_primaryKey == key)
            {
                configData = temp;
            }
        }
        return configData;
    }

    public static MusicConfig GetInstance()
    {
        return Singleton<MusicConfig>.GetInstance();
    }

    #region 重写父类读取数据方法
    public override void ReadConfig()
    {
        int temp = -1;
      
        for (int i = 1; i < m_rows; i++)
        {
            MusicConfigData musicConfig = new MusicConfigData();

            musicConfig.m_index = Tools.ToInt(GetValue(i, 0));

            musicConfig.m_primaryKey = Tools.ToInt(GetValue(i, 1));
           
            musicConfig.m_fileName = GetValue(i, 2);
            
            temp = Tools.ToInt(GetValue(i, 3));
            
            if (temp == 1)
	        {
                musicConfig.m_musicType = MusicType.BackgroudMusic;
	        }
            else if (temp == 2)
            {
                musicConfig.m_musicType = MusicType.SpecialEffectMusic;              
            }

            temp = Tools.ToInt(GetValue(i, 4));
           
            if (temp == 1)
            {
                musicConfig.m_cycleTag = MusicCycleTag.Recyclable;
            }
            else if (temp == 2)
            {
                musicConfig.m_cycleTag = MusicCycleTag.Unrecyclable;
            }

            temp = Tools.ToInt(GetValue(i, 5));

            if (temp == 1)
            {
                musicConfig.m_cachable = CacheTag.Cachable;
            }
            else if (temp == 2)
            {
                musicConfig.m_cachable = CacheTag.Uncachable;
            }

            m_configData.Add(musicConfig);
        }

        if (m_configData.Count != 0)
        {
            MusicManager.GetInstance().SetMusicConfig(m_configData);
        }
    }

    public override void Init()
    {
        m_configFileName = "Config/Music.xlsx";
    }
    #endregion
}
