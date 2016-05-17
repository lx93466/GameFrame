using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class test : Selectable
{

	// Use this for initialization
	void Start () {
        //EventTrigger.Entry entry2 = new EventTrigger.Entry();

        //entry2.eventID = EventTriggerType.PointerDown;

        //entry2.callback = new EventTrigger.TriggerEvent();

        //UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(OnPointerDown);

        //entry2.callback.AddListener(callback);

        //var trigger = transform.GetComponent<EventTrigger>();

        //if (trigger == null)
        //{
        //    trigger = transform.gameObject.AddComponent<EventTrigger>();
        //}

        //trigger.triggers.Add(entry2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        PointerEventData data = eventData as PointerEventData;
        Debug.Log("OnPointerDown: " + EventSystem.current.currentSelectedGameObject);
    }

    public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("OnPointerUp: " + eventData.pointerPress.name);

    }
}
