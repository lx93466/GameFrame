using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameFrame
{
    class ResourceManager : Singleton<ResourceManager>
    {
        //音乐，特效音乐缓存
        Dictionary<string, AudioClip> m_audios = new Dictionary<string, AudioClip>(); 
      

        public ResourceManager() { }

        public Stream ReadConfig(string file)
        {
            Stream stream = null;

            string path = GameFrame.Tools.GetAppDir() + file;

            if (File.Exists(path))
            {
                stream = File.Open(path, FileMode.Open);
            }
            else
            {
                Debug.LogWarning("File[" + path + "] is not exist.");
            }

            return stream;
        }

        public AudioClip ReadAudioClip(string file, CacheTag cachable)
        {
            AudioClip clip = null;

            if(!m_audios.TryGetValue(file, out clip))
            {               
                clip = Resources.Load(file) as AudioClip;

                if (clip != null && CacheTag.Cachable == cachable)
                {
                    m_audios.Add(file, clip);                        
                }
                
            }
            return clip;
        }

        public GameObject LoadAsset(string file)
        {
            GameObject go = Resources.Load<GameObject>(file);

            if (go == null)
            {
                Tools.AddWarming("ResourceManager.LoadAsset[" + file + "] failed.");
            }
            return go;
        }
    }
}


