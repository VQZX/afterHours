using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    public class SpeechBubble : MonoBehaviour
    {
        [SerializeField]
        protected AnimatedText content;

        [SerializeField]
        protected GameObject animatedElipsis;

        [SerializeField]
        protected int elipsisCount;

        [SerializeField]
        protected bool takeDimensions = true;

        protected int originalFontSize;

        protected ConversationManager manager;
        protected Statement statement;
        protected RectTransform rectTransform;

        public virtual void ElipsisBegin()
        {
            
        }
        
        public virtual void ElipsisComplete()
        {
            
        }
        
        
        public virtual void Play(ConversationManager manager, Statement statement)
        {
            this.manager = manager;
            this.statement = statement;
            
            //adjust sizes
            if (takeDimensions)
            {
                rectTransform.anchoredPosition = statement.Measurements.AnchoredPosition;
                rectTransform.sizeDelta = statement.Measurements.SizeDelta;
            }
            
            content.Play(statement.Content, statement.Curve);
        }

        protected virtual void Awake()
        {
            if (content != null)
            {
                content.Complete += OnComplete;
            }
            if (animatedElipsis != null)
            {
                animatedElipsis.gameObject.SetActive(false);
            }

            rectTransform = (RectTransform) transform;
            originalFontSize = GetComponentInChildren<Text>().fontSize;
        }

        private void OnComplete()
        {
            if (manager != null)
            {
                manager.DisplayNext(statement);
            }
        }
    }
}