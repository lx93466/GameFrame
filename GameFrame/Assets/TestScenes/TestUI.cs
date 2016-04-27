using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;

public class TestUI : MonoBehaviour {
    
    public GameObject buttonObj;

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "";
        UIEventListener listener = Tools.GetComponent<UIEventListener>(buttonObj);
        listener.onClick = click;
        listener.onClickDown = clickDown;
        listener.onClickUp = clickUp;

        listener.onBeginDrag = beginDrag;

        listener.onDrag = drag;

        listener.onEndDrag = endDrag;

        listener.onScroll = scroll;
	}
	
	void click(UIEventData uiEventData)
    {
        text.text += "click\n";      
    }

    void clickDown(UIEventData uiEventData)
    {
        text.text += "clickDown\n";
    }

    void clickUp(UIEventData uiEventData)
    {
        text.text += "clickUp\n";
    }

    void move(UIEventData uiEventData)
    {
        text.text += "move\n";
    }

    void beginDrag(UIEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void drag(UIEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void endDrag(UIEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void scroll(UIEventData uiEventData)
    {

    }
 
}
