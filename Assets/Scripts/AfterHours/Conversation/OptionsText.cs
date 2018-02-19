using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    [RequireComponent(typeof(Text))]
    public class OptionsText : ResponseButton, IPointerClickHandler
    {
        [SerializeField]
        protected Text text;

        public Action OnSelect;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (OnSelect != null)
            {
                OnSelect();
            }
        }

        public void SetText(string option)
        {
            text.text = option;
            gameObject.name = option;
        }
    }
}