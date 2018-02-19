using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    public class OptionsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Text text;

        [SerializeField] protected Image image;

        [SerializeField]
        public Color bubbleOnColor, bubbleOffColor, textOnColor, textOffColor;

        /// <summary>
        /// The canvas group to control this and children alpha
        /// </summary>
        private CanvasGroup canvasGroup;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            HoverState(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            HoverState(false);
        }

        public void Disable()
        {
            SetGroup(0.3f, false);
        }

        public void Enable()
        {
           SetGroup(1, true); 
        }
        
        public void SetGroup(float alpha, bool state )
        {
            canvasGroup.alpha = alpha;
            canvasGroup.interactable = state;
            canvasGroup.blocksRaycasts = state;
        }

        protected virtual void Awake()
        {
            HoverState(false);
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void OnEnable()
        {
            Enable();
        }
        

        private void HoverState(bool state)
        {
            text.color = state ? textOnColor : textOffColor;
            image.color = state ? bubbleOnColor : bubbleOffColor;
        }
    }
}