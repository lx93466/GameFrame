using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


namespace GameFrame
{
    public class UIEventListener : MonoBehaviour,
                               IPointerClickHandler,
                               IPointerDownHandler,
                               IPointerUpHandler,
                               IDropHandler,
                               IBeginDragHandler,
                               IDragHandler,
                               IEndDragHandler
    {
        public delegate void UIEventHandle1(PointerEventData uiEventData);
        public delegate void UIEventHandle2(Vector2 v2);

        public UIEventHandle1 onClick;

        public UIEventHandle1 onClickUp;

        public UIEventHandle1 onClickDown;

        public UIEventHandle1 onBeginDrag;

        public UIEventHandle1 onDrag;

        public UIEventHandle1 onEndDrag;

        public UIEventHandle1 onDrop;

        public UIEventHandle2 onScroll;

        void start()
        {
            if (onScroll != null)
            {
                ScrollRect scrollRect = transform.GetComponent<ScrollRect>();

                UnityAction<Vector2> action = new UnityAction<Vector2>(this.onScroll);
                scrollRect.onValueChanged.AddListener(action);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onClick != null)
            {                                  
                onClick(eventData );
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (onClickDown != null)
            {
                onClickDown(eventData );
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
         
            if (onClickUp != null)
            {
                onClickUp(eventData );
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (onDrag != null)
            {
                onBeginDrag(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (onDrag != null)
            {
                onDrag(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (onEndDrag != null)
            {
                onEndDrag(eventData);
            }
        }
        /// <summary>
        /// 当使用OnDrop事件时，为了使被拖动对象A能够掉落到接受Drop事件的对象B身上，
        /// B必须优于A渲染，即：B对象位于A对象下边。
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (onDrop != null)
            {
                onDrop(eventData);
            }
        }

        public void OnScroll(Vector2 v2)
        {
            if (onScroll != null)
            {
                onScroll(v2);
            }
        }
    }
}
