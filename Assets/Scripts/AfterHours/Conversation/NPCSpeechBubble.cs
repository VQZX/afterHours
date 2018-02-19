using UnityEngine;

namespace AfterHours.Conversation
{
    public class NPCSpeechBubble : SpeechBubble
    {
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
            
            // adjust size
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
                content.Play(statement.Content, statement.Curve);
            }
        }
    }
}