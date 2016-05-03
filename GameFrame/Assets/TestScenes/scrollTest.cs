using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;

public class scrollTest : MonoBehaviour {
    /// <summary>
    /// 构造器实参可以为具有特点格式的委托，如：本处可以为委托
    /// public delegate void UIEventHandle2( Vector2 v2 )的对象，
    /// 即：UIEventHandle2 scroll;
    /// </summary>
    void Start ()
     {
         var trigger = transform.GetComponent<EventTrigger>();

         if (trigger == null)
         {
             trigger = transform.gameObject.AddComponent<EventTrigger>();
         }

         trigger.triggers = new List<EventTrigger.Entry>();

         EventTrigger.Entry entry1 = new EventTrigger.Entry();

         entry1.eventID = EventTriggerType.PointerClick;

         entry1.callback = new EventTrigger.TriggerEvent();

         UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(Click);

         entry1.callback.AddListener(callback);

         trigger.triggers.Add(entry1);
        
         EventTrigger.Entry entry2 = new EventTrigger.Entry();

         entry2.eventID = EventTriggerType.PointerUp;

         entry2.callback = new EventTrigger.TriggerEvent();

         callback = new UnityAction<BaseEventData>(ClickUp);

         entry1.callback.AddListener(callback);

         trigger.triggers.Add(entry2);

         UnityAction<Vector2> action = new UnityAction<Vector2>(Scroll);
         ScrollRect scrollRect = transform.GetComponent<ScrollRect>();
         if (scrollRect != null)
         {
             scrollRect.onValueChanged.AddListener(action);
        }
     }

     public void Click(BaseEventData arg0)
     {
         Debug.Log("Test Click");
     }

     public void ClickUp(BaseEventData arg0)
     {
         Debug.Log("Test ClickUp");
     }

     public void Scroll(Vector2 v2)
     {
         Debug.Log("Scroll, v2 arg:" + v2.ToString());
     }

     public void LockScreen()
     {
         Tools.LockScreen();
     }

     public void UnLockScreen()
     {
         Tools.UnlockScreen();
     }

     public void CreateEmptyObject()
     {
         Tools.CreatEmptyGameObject();
     }
}
