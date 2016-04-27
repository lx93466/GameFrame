using UnityEngine;
using System.Collections;

public class RotateAnimation : MonoBehaviour {
    public float rotateX = 0;
    public float rotateY = 0;
    public float rotateZ = 0;
    public float rotateTime = 1.0f;
    public float delayTime = 1.0f;
    public Direction direction = Direction.To;
    
    Hashtable ht = new Hashtable();

    void Awake()
    {
        //ht.Add("x", moveToX);
        //ht.Add("y", moveToY);
        //ht.Add("z", moveToZ);
        //ht.Add("time", moveTime);
        //ht.Add("delay", delayTime);
        //ht.Add("looptype", iTween.LoopType.none);
    }
    void Start()
    {
        iTween.RotateTo(gameObject, new Vector3(rotateX, rotateY, rotateZ), rotateTime);
        //if (direction == Direction.To)
        //{
        //    iTween.MoveTo(gameObject, ht);
        //}
        //else
        //{
        //    iTween.MoveFrom(gameObject, ht);
        //}
    }	
}
