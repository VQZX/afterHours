using AfterHours.Conversation;
using Flusk;
using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Part1
{
    public class FirstConversationWithHolden : VideoInteraction
    {
        [SerializeField]
        protected ConversationManager manager;

        [SerializeField]
        protected MinutesAndSeconds returnTime;

        [SerializeField] protected float timeBeforeHide = 3f;

        [SerializeField]
        protected Part1Flags skipJamesFlag;

        private Timer timer;

        protected virtual void Awake()
        {
            manager.ConversationEnded += OnConversationEnded;
        }

        protected virtual void Update()
        {
            if (timer != null)
            {
                timer.Tick(Time.deltaTime);
            }
        }
        
        private void OnConversationEnded()
        {
            manager.ConversationEnded -= OnConversationEnded;
            timer = new Timer(timeBeforeHide, Hide);
        }
        
    }
}