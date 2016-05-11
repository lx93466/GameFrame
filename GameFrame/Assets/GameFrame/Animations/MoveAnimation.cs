using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour {
    public float moveToX = 0;
    public float moveToY = 0;
    public float moveToZ = 0;
    public float moveTime = 1.0f;
    public float delayTime = 1.0f;
    public Direction direction = Direction.To;
    Hashtable ht = new Hashtable();
    void Awake()
    {
        ht.Add("x", moveToX);
        ht.Add("y", moveToY);
        ht.Add("z", moveToZ);
        ht.Add("time", moveTime);
        ht.Add("delay", delayTime);
        ht.Add("looptype", iTween.LoopType.none);
    }
    void Start()
    {
        if (direction == Direction.To)
        {
            iTween.MoveTo(gameObject, ht);
        }
        else
        {
            iTween.MoveFrom(gameObject, ht);
        }
    }	
}
