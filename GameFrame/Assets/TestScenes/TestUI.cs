using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;
using UnityEngine.EventSystems;

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

    void click(PointerEventData uiEventData)
    {
        text.text += "click\n";      
    }

    void clickDown(PointerEventData uiEventData)
    {
        text.text += "clickDown\n";
    }

    void clickUp(PointerEventData uiEventData)
    {
        text.text += "clickUp\n";
    }

    void move(PointerEventData uiEventData)
    {
        text.text += "move\n";
    }

    void beginDrag(PointerEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void drag(PointerEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void endDrag(PointerEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void scroll(PointerEventData uiEventData)
    {

    }
 
}
