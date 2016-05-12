using UnityEngine;
using System.Collections;
using GameFrame;


public class CameraFollowing : GameBehaviour {

    public static Msg cameraMovingMsg = new Msg();

    protected override void Init()
    {
        RegisterMsg(cameraMovingMsg, Moving);
    }
	
    void Moving(MsgArg args)
    {
        transform.position = args.v4;
    }

}
