using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;
using UnityEngine.EventSystems;

public class TestUI : MonoBehaviour {
    
    public GameObject buttonObj;

    public GameObject dropImg;

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "";
       
        UIEventListener buttonListener = Tools.GetComponent<UIEventListener>(buttonObj);

        buttonListener.onClick = click;
       
        buttonListener.onClickDown = clickDown;
      
        buttonListener.onClickUp = clickUp;

        buttonListener.onBeginDrag = beginDrag;

        buttonListener.onDrag = drag;

        buttonListener.onEndDrag = endDrag;

        buttonListener.onScroll = scroll;

        UIEventListener dropListener = Tools.GetComponent<UIEventListener>(dropImg);

        dropListener.onDrop = drop;
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

    void beginDrag(PointerEventData uiEventData)
    {
        Debug.Log("beginDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y + "]");
    }

    void drag(PointerEventData uiEventData)
    {
        uiEventData.pointerDrag.transform.position = new Vector3(uiEventData.position.x, uiEventData.position.y, 0);
        Debug.Log("drag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y + "]");
    }

    void endDrag(PointerEventData uiEventData)
    {
        Debug.Log("endDrag:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y);
    }

    void scroll(PointerEventData uiEventData)
    {
        Debug.Log("scroll");
    }
    void drop(PointerEventData uiEventData)
    {
        text.text = "drop";
        uiEventData.pointerDrag.transform.position = new Vector3(uiEventData.position.x, uiEventData.position.y, 0);
        Debug.Log("*********************drop:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y + "]");
    }
}
