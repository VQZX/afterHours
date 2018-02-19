using System;
using Flusk.Attributes;

namespace AfterHours.Interaction.Interactions.Part1
{
    [Flags]
    public enum Part1Flags
    {
        /// <summary>
        /// In reference to this dialogue:
        /// "Well I said I'm fine so I must be."
        /// </summary>
        LiedToHolden = 1 << 0,
        
        /// <summary>
        /// In reference to this dialogue:
        /// "I feel really ugly and shit...if you paid any attention to me today you would know."
        /// </summary>
        AccusedHolden = 1 << 1
    }
}