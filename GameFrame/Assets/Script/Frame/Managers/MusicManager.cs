using UnityEngine;
using System.Collections;
namespace GameFrame
{
    class MusicManager : Singleton<MusicManager>
    {
        ArrayList m_musicConfig = null;
       
        GameObject m_audioObject = null;

        AudioSource m_backgroudMusicAudioSource = null;
     
        AudioSource m_specialEffectMusicAudioSource = null;


        MusicConfigData GetMusicConfigByPrimaryKey(int key)
        {
            MusicConfigData configData = null;

            MusicConfigData temp = null;

            if (m_musicConfig != null)
            {
                foreach (var config in m_musicConfig)
                {
                    temp = config as MusicConfigData;
                    if (temp != null && temp.m_primaryKey == key)
                    {
                        configData = temp;
                    }
                }    
            }
            
            return configData;
        }

        public void SetMusicConfig(ArrayList musicConfig)
        {
            m_musicConfig = musicConfig;
        }


        /// <summary>
        /// musicPrimaryId:音乐配置表主键ID
        /// replay：如果正在播放，是否重新播放
        /// </summary>
        /// <param name="musicPrimaryId"></param>
        /// <param name="rePlay"></param>
        public void PlayMusic(int musicPrimaryId, bool replay = false)
        {
            if (m_audioObject == null)
            {
                m_audioObject = GameObject.Find("Audio");
                
                if (m_audioObject == null)
                {
                    m_audioObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                    m_audioObject.name = "Audio";

                    m_audioObject.GetComponent<MeshRenderer>().enabled = false;

                    m_backgroudMusicAudioSource = m_audioObject.AddComponent<AudioSource>();

                    m_specialEffectMusicAudioSource = m_audioObject.AddComponent<AudioSource>();

                    m_backgroudMusicAudioSource.loop = true;

                    m_backgroudMusicAudioSource.spread = 200;

                    m_specialEffectMusicAudioSource.loop = false;

                    m_specialEffectMusicAudioSource.spread = 200;
                }             
            }            

            MusicConfigData config = GetMusicConfigByPrimaryKey(musicPrimaryId);
            if (config != null)
            {
                AudioClip clip = ResourceManager.GetInstance().ReadAudioClip("Music/" + config.m_fileName, config.m_cachable);
                if (clip != null)
                {
                    if (config.m_musicType == MusicType.SpecialEffectMusic)
                    {
                        if (m_specialEffectMusicAudioSource.clip == clip && m_specialEffectMusicAudioSource.isPlaying)
                        {
                            if (replay)
                            {
                                m_specialEffectMusicAudioSource.clip = clip;

                                m_specialEffectMusicAudioSource.Play();
                            }
                            else
                            {
                                Tools.AddWarming("当前特效音乐正在播放");
                            }                          
                        }
                        else
                        {
                            m_specialEffectMusicAudioSource.clip = clip;

                            m_specialEffectMusicAudioSource.Play();
                        }                      
                    }
                    else if (config.m_musicType == MusicType.BackgroudMusic)
                    {
                        if (m_backgroudMusicAudioSource.clip == clip && m_backgroudMusicAudioSource.isPlaying)
                        {
                            if (replay)
                            {
                                m_backgroudMusicAudioSource.clip = clip;

                                m_backgroudMusicAudioSource.Play();
                            }
                            else
                            {
                                Tools.AddWarming("当前背景音乐正在播放");
                            }                          
                        }
                        else
                        {
                            m_backgroudMusicAudioSource.clip = clip;

                            m_backgroudMusicAudioSource.Play();
                        }                        
                    }
                }
                else
                {
                    Tools.AddWarming("没有读取到音乐文件。");
                }
            }
            else
            {
                Tools.AddWarming("背景音乐无法播放，可能原因：1.配置表没有相关配置。 \n 2. 没有设置MusicManager配置信息。");
            }
        }

        public void StopAllMusic()
        {
            if (m_audioObject != null)
            {
                GameObject.DestroyObject(m_audioObject);
            }
        }

        public void StopMusic(int musicPrimaryId)
        {
             MusicConfigData config = GetMusicConfigByPrimaryKey(musicPrimaryId);
             if (config != null)
             {
                 if (config.m_musicType == MusicType.BackgroudMusic)
                 {
                     m_backgroudMusicAudioSource.Stop();
                 }
                 else if (config.m_musicType == MusicType.SpecialEffectMusic)
                 {
                     m_specialEffectMusicAudioSource.Stop();
                 }
             }
        }
    }
}
