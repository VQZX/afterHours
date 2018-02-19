using System;
using AfterHours.Conversation;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1.IgnoreJamesAndMaryam
{
    public class JamesAndMaryam : VideoInteraction
    {
        [SerializeField]
        protected ConversationManager james;

        private void OnMaryamComplete()
        {
            Hide();
        }
    }
}
