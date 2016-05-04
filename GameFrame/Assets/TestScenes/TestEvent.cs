using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;

public class TestEvent : MonoBehaviour {
    
    public GameObject buttonObj;

    public GameObject scrollObj;

    public Text text;

    public Text tips;

    ScrollRect scrollRect;

    int i = 0;

	// Use this for initialization
	void Start () {
        text.text = "";

       // UnityEvent event1;

        UIEventListener buttonListener = Tools.GetComponent<UIEventListener>(buttonObj);

        buttonListener.onClick = click;
       
        buttonListener.onClickDown = clickDown;
      
        buttonListener.onClickUp = clickUp;

        buttonListener.onBeginDrag = beginDrag;

        buttonListener.onDrag = drag;

        buttonListener.onEndDrag = endDrag;

        buttonListener.onScroll = scroll;

        UIEventListener dropListener = Tools.GetComponent<UIEventListener>(scrollObj);

        dropListener.onDrop = drop;

       
    }


    void click(PointerEventData uiEventData)
    {
       

        text.text += "click " + i + "\n";
        text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight);
    }

    void clickDown(PointerEventData uiEventData)
    {
        i++;
        text.text += "clickDown " + i + "\n";      
    }

    void clickUp(PointerEventData uiEventData)
    {
        text.text += "clickUp " + i + "\n";  
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

    void scroll(Vector2 v2)
    {
        Debug.Log("scrollValueChanged, v2 = " + v2.ToString());
    }
   
    void drop(PointerEventData uiEventData)
    {
        text.text = "drop";
        uiEventData.pointerDrag.transform.position = new Vector3(uiEventData.position.x, uiEventData.position.y, 0);
        Debug.Log("*********************drop:GameObject[" + uiEventData.pointerDrag.name + "], Position[x:" + uiEventData.position.x + ", y:" + uiEventData.position.y + "]");
    }
}
