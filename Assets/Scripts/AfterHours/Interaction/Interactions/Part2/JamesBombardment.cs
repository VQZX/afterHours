using System.Collections.Generic;
using AfterHours.Conversation;
using Flusk;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class JamesBombardment : VideoInteraction
    {
        [SerializeField]
        protected ConversationManager [] conversationManager;

        [SerializeField]
        protected CircleBob[] circleBobs;

        [SerializeField]
        protected Animator bombardmentMotion;

        [SerializeField]
        protected float time = 5f;
        
        private Timer timer;

        public override void Show()
        {
            gameObject.SetActive(true);
            base.Show();
            int length = conversationManager.Length;
            for (int i = 0; i < length; i++)
            {
                conversationManager[i].Activate();
            }
            timer = new Timer(time, OnTimerEnd);
        }

        public override void Hide()
        {
            base.Hide();
            gameObject.SetActive(false);
            timer = null;
        }
        
        private void OnTimerEnd()
        {
            bombardmentMotion.SetBool("Fly", true);
        }

        protected virtual void Update()
        {
            if (timer != null)
            {
                timer.Tick(Time.deltaTime);
            }
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            conversationManager = GetComponentsInChildren<ConversationManager>();
        }
#endif
    }
}