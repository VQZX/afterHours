using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Events;

namespace AfterHours.Conversation
{
    public class Statement : MonoBehaviour
    {
        public enum Type
        {
            Player,
            
            NPC,
            
            SoundEffect
        }

        [Serializable]
        public struct SpeechBubbleMeasurements
        {
            public Vector2 AnchoredPosition;

            public Vector2 SizeDelta;

            public SpeechBubbleMeasurements(Vector2 anchored, Vector2 size)
            {
                AnchoredPosition = anchored;
                SizeDelta = size;
            }

            public SpeechBubbleMeasurements(RectTransform rectTransform) 
                : this (rectTransform.anchoredPosition, rectTransform.sizeDelta)
            {
            }
        }
        
        [Multiline(10),SerializeField]
        protected string content;

        [SerializeField]
        protected Type mode;
        
        [SerializeField]
        protected List<Statement> responses;

        [SerializeField]
        protected AnimationCurve curve;

        [SerializeField] 
        protected SpeechBubbleMeasurements measurements;

        [SerializeField] 
        protected SpeechBubbleMeasurements optionMeasurements;

        [SerializeField] 
        protected bool overrideTextSize;

        [SerializeField] 
        protected int fontSize = 105;

        [SerializeField]
        protected bool overrideEvent;

        [SerializeField]
        protected bool addEvent;

        [SerializeField] 
        protected RectTransform speechBubble;

        [SerializeField] protected RectTransform optionsSpeechBubble;
        
#if UNITY_EDITOR
        public RectTransform SpeechBubble {get { return speechBubble; }}
        public RectTransform OptionsSpeechBubble {get { return optionsSpeechBubble; }}
#endif

        public UnityEvent OverrideOnSelected;

        public UnityEvent AddSelected;

        public Action<Statement> Selected;
        
        public string Content { get { return content; } }
        
        public Type Mode {get { return mode; }}

        public AnimationCurve Curve { get { return curve; } }
        
        public SpeechBubbleMeasurements Measurements
        {
            get { return measurements; }
        }
        
        public SpeechBubbleMeasurements OptionMeasurements
        {
            get { return optionMeasurements; }
        }

        public bool MustOverrideText
        {
            get { return overrideTextSize; }
        }

        public int OverrideFontSize
        {
            get { return fontSize; }
        }

        public bool OverrideEvent
        {
            get { return overrideEvent; }
        }

        public bool AddEvent
        {
            get { return addEvent; }
        }

        public List<Statement> Responses
        {
            get { return responses; }
        }
        
        public RectTransform RectTransform { get; protected set; }
        
        /// <summary>
        /// Used to determine the end of a conversation
        /// </summary>
        public bool IsLeaf {get { return Responses == null || Responses.Count == 0; }}
        
        /// <summary>
        /// The only time we have options is if this statement has more than one
        /// child statement
        /// </summary>
        public bool ChildrenAreOptions { get { return Responses.Count > 1; } }
        
        /// <summary>
        /// Whether this statement is an option
        /// </summary>
        public bool IsAnOption { get; set; }

#if UNITY_EDITOR
        public void SetStatementRect()
        {
            SpeechBubble.anchoredPosition = measurements.AnchoredPosition;
            SpeechBubble.sizeDelta = measurements.SizeDelta;
            SpeechBubble.GetComponentInChildren<UnityEngine.UI.Text>().text = content;
        }

        public void SetOptionsRect()
        {
            OptionsSpeechBubble.anchoredPosition = optionMeasurements.AnchoredPosition;
            OptionsSpeechBubble.sizeDelta = optionMeasurements.SizeDelta;
            OptionsSpeechBubble.GetComponentInChildren<UnityEngine.UI.Text>().text = content;
        }
#endif
        public void Select()
        {
            if (Selected != null)
            {
                Selected(this);
            }
        }

        public void SetStatementMeasurements(RectTransform rectTransform)
        {
            measurements = new SpeechBubbleMeasurements(rectTransform);
        }

        public void SetOptionsMeasurements(RectTransform rectTransform)
        {
            optionMeasurements = new SpeechBubbleMeasurements(rectTransform);
        }
        

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            gameObject.name = content.Replace('\n', ' ');
            if (responses != null && responses.Count != 0)
            {
                return;
            }
            int count = transform.childCount;
            if (count == Responses.Count)
            {
                return;
            }
            
            foreach (Transform child in transform)
            {
                var current = child.GetComponent<Statement>();
                if (current == null)
                {
                    continue;
                }
                current.IsAnOption = count > 1;
                Responses.Add(current);
            }
            
        }
#endif
    }
}