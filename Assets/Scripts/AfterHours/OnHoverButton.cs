using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AfterHours
{
    public class OnHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        protected UnityEvent enter, exit;


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