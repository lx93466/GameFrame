﻿using UnityEngine;
using System.Collections;
using GameFrame;

public class MusicTest : MonoBehaviour {
    public AudioClip clip1;
    public AudioClip clip2;
	// Use this for initialization
	void Start () {
        ConfigManager.GetInstance().Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(int i)
    {      
        if (i == 1)
        {
            MusicManager.GetInstance().PlayMusic(1001);
        }
        else if (i == 2)
        {
            MusicManager.GetInstance().PlayMusic(1004, true);
        }
    }

    public void Stop(int id)
    {
        if (id > 0)
        {
            MusicManager.GetInstance().StopMusic(id);
        }
        else
        {
            MusicManager.GetInstance().StopAllMusic();
        }
    }
}
