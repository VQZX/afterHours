using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1
{
    public class FlagEvents : MonoBehaviour
    {
        [SerializeField]
        protected Part1GameFlags flags;

        [SerializeField]
        protected FlowManager flowManager;

        [SerializeField]
        protected Part1Flags skipJamesFlag;

        /// <summary>
        /// The time to skip to
        /// </summary>
        [SerializeField]
        protected MinutesAndSeconds skipTime;
        
        public void SkipJames()
        {
            if (flags.HasFlag(skipJamesFlag))
            {
                flowManager.SetTime(skipTime.Minutes, skipTime.Seconds, false);   
            }
        }
    }
}