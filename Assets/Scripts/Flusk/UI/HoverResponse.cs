using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Flusk.UI
{
    public class HoverResponse : IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        protected UnityEvent enter;

        [SerializeField]
        protected UnityEvent exit;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            enter.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            exit.Invoke();
        }
    }
}