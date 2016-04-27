using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


namespace GameFrame
{
    public class UIEventListener : MonoBehaviour,
                               IPointerClickHandler,
                               IPointerDownHandler,
                               IPointerUpHandler,
                               IDropHandler,
                               IBeginDragHandler,
                               IDragHandler,
                               IEndDragHandler,
                               IScrollHandler                             
    {
        public delegate void UIEventHandle(PointerEventData uiEventData);

        public UIEventHandle onClick;

        public UIEventHandle onClickUp;

        public UIEventHandle onClickDown;

        public UIEventHandle onBeginDrag;

        public UIEventHandle onDrag;

        public UIEventHandle onEndDrag;

        public UIEventHandle onDrop;

        public UIEventHandle onMove;

        public UIEventHandle onScroll;

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

        public void OnDrop(PointerEventData eventData)
        {
            if (onDrop != null)
            {
                onDrop(eventData);
            }
        }

        public void OnScroll(PointerEventData eventData)
        {
            if (onScroll != null)
            {
                onScroll(eventData);
            }
        }
    }
}
