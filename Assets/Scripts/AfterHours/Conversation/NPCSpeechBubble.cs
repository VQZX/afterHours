using System;
using AfterHours.Beta;
using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    public class NPCSpeechBubble : SpeechBubble
    {
        [Serializable]
        public struct BubbleSelection
        {
            public Statement.NPC Npc;
            public Sprite Bubble;
            public Sprite NameTag;
        }

        [SerializeField]
        protected Image image;

        [SerializeField]
        protected SpeechBubbleContainer container;

        [SerializeField]
        protected SpeechBubbleContainer smallContainer;
        
        [SerializeField]
        protected int elipsisCycles = 3;
        
        public int ElipsisCycles
        {
            get { return elipsisCycles; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                elipsisCycles = value;
            }
        }
        
        private int currentCycles;

        public override void Play(ConversationManager manager, Statement statement)
        {
            this.manager = manager;
            this.statement = statement;

            image.sprite = statement.UseSmall ? 
                smallContainer[statement.Npc] : 
                container[statement.Npc];
            
            // Adjust size
            rectTransform.anchoredPosition = statement.Measurements.AnchoredPosition;
            rectTransform.sizeDelta = statement.Measurements.SizeDelta;
            
            content.gameObject.SetActive(false);
            animatedElipsis.gameObject.SetActive(true);
        }

        public override void ElipsisComplete()
        {
            currentCycles++;
            if (currentCycles >= elipsisCycles)
            {
                animatedElipsis.gameObject.SetActive(false);
                //content.Play(statement.Content, statement.Curve);
                content.InstantPlay(statement.Content, statement.Curve);
            }
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            image = GetComponent<Image>();
        }
#endif
    }
}