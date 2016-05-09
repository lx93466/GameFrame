using UnityEngine;
using System.Collections;
using GameFrame;

public class StartGame : MonoBehaviour {

    void Awake()
    {
        GameApp.GetInstance().InitGame();
    }
    void Start()
    {
        GameApp.GetInstance().StartGame();        
    }
}
