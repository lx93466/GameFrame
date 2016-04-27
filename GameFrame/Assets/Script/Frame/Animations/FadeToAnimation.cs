using UnityEngine;
using System.Collections;

public class FadeToAnimation : MonoBehaviour {

    public float alpha = 0.0f;
    public float time = 1.0f;
    public float delayTime = 1.0f;

    Hashtable ht = new Hashtable();
  
   void Awake()
    {
        ht.Add("amount", alpha);
        ht.Add("time", time);
        ht.Add("delay", delayTime);
        ht.Add("looptype", iTween.LoopType.none);
    }
    void Start()
    {
        iTween.FadeTo(gameObject, ht);
    }	
}
