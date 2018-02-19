using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    /// <summary>
    /// ALLOW FOR VARIABLE AMOUNTS OF OPTIONS!
    /// </summary>
    public class OptionsContainer : MonoBehaviour
    {
        [SerializeField] 
        protected RectTransform[] optionTransforms;
        
        [SerializeField]
        protected Button[] buttons;
        
        [SerializeField]
        protected Text[] texts;

        private ConversationManager manager;

        public void Display(ConversationManager manager, Statement statement)
        {
            this.manager = manager;
            gameObject.SetActive(true);
            int length = statement.Responses.Count;
            for (int i = 0; i < length; i++)
            {
                var current = statement.Responses[i];
                
                // adjust sizes
                optionTransforms[i].anchoredPosition = current.OptionMeasurements.AnchoredPosition;
                optionTransforms[i].sizeDelta = current.OptionMeasurements.SizeDelta;
                
                // add content
                texts[i].text = current.Content;
                if (current.MustOverrideText)
                {
                    texts[i].fontSize = current.OverrideFontSize;
                }
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(() => Select(current));
            }
        }

        public void Select(Statement statement)
        {
            if (!statement.OverrideEvent)
            {     
                manager.DisplayStatement(statement);
                FlowManager fm;
                if (FlowManager.TryGetInstance(out fm))
                {
                    fm.PlayVideo();
                }
                if (statement.AddEvent)
                {
                    statement.AddSelected.Invoke();
                }
            }
            else
            {
                statement.OverrideOnSelected.Invoke();
            }
        }
    }
}