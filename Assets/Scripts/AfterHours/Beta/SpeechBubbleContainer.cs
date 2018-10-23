using System.Collections.Generic;
using System.Linq;
using AfterHours.Conversation;
using UnityEngine;

namespace AfterHours.Beta
{
    [CreateAssetMenu(fileName = "SpeechBubbleContainer.asset", menuName = "SpeechBubbleContainer")]
    public class SpeechBubbleContainer : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        protected List<NPCSpeechBubble.BubbleSelection> speechBubbleSelection;

        private Dictionary<Statement.NPC, NPCSpeechBubble.BubbleSelection> selection;

        public Sprite this[Statement.NPC npc]
        {
            get { return selection[npc].Bubble; }
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            selection = speechBubbleSelection.ToDictionary(data => data.Npc);
        }
    }
}