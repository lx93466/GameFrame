using System.IO;
using UnityEngine;

namespace GameFrame
{
    class ResourceManager : Singleton<ResourceManager>
    {
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

        public AudioClip ReadAudioClip(string file)
        {   
            return Resources.Load(file) as AudioClip;
        }
    }
}


