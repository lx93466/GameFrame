using UnityEngine;
using System.Collections;

public class ScaleAnimation : MonoBehaviour
{
    public float fromX = 1;
    public float fromY = 1;
    public float fromZ = 1;

    public float toX = 1;
    public float toY = 1;
    public float toZ = 1;
    public float scaleTime = 0.5f;
    public float delayTime = 0.5f;
    public bool disableUIEvent = true;
    //暂未实现
    GameObject eventSystem = null;
    Hashtable ht = new Hashtable();
    void Awake()
    {
        ht.Add("x", toX);
        ht.Add("y", toY);
        ht.Add("z", toZ);
        ht.Add("time", scaleTime);
        ht.Add("delay", delayTime);
        ht.Add("looptype", iTween.LoopType.none);

        eventSystem = GameObject.Find("");
    }
    void Start()
    {
        if (disableUIEvent)
        {

        }
        Transform transform = gameObject.transform;
        transform.localScale = new Vector3(fromX, fromY, fromZ);
        iTween.ScaleTo(gameObject, ht);
    }	
}
