using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class LoveYourself : VideoInteraction
    {
        [SerializeField]
        protected LoveText[] loveText;

        [SerializeField]
        protected List<LoveButton> buttons;

        public void OnPressed(LoveButton button)
        {
            int index = buttons.FindIndex(b => b == button);
            
            loveText[index].Clicked();
        }
    }
}