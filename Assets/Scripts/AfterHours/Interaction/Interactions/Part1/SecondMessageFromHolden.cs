using AfterHours.Conversation;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1
{
    public class SecondMessageFromHolden : VideoInteraction
    {
        [SerializeField]
        protected ConversationManager liedToHolden;

        [SerializeField]
        protected Part1Flags liedFlag;

        [SerializeField]
        protected ConversationManager abusiveToHolden;

        [SerializeField]
        protected Part1Flags abusedFlag;

        public override void Show()
        {
            var flagController = Part1GameFlags.Get();
            if (flagController == null)
            {
                return;
            }
            base.Show();
            #if UNITY_EDITOR
            if (flagController.UseDummy)
            {
                if (flagController.DummyFlag == liedFlag)
                {
                    liedToHolden.Activate();
                }
                else if (flagController.DummyFlag == abusedFlag)
                {
                    abusiveToHolden.Activate();
                }
                return;
            }
            #endif
            if (flagController.HasFlag(liedFlag))
            {
                liedToHolden.Activate();
            }
            else if (flagController.HasFlag(abusedFlag))
            {
                abusiveToHolden.Activate();
            }
        }
    }
}