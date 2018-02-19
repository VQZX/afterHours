using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    public class ConversationManager : MonoBehaviour
    {
        /// <summary>
        /// The content that holds all the selected conversation branches
        /// </summary>
        [SerializeField]
        protected RectTransform contentParent;

        /// <summary>
        /// The transform that holds all the the options to select
        /// </summary>
        [SerializeField]
        protected RectTransform optionsParent;
        
        /// <summary>
        /// The prefab for what the players response resides in
        /// </summary>
        [SerializeField]
        protected SpeechBubble playerStatement;

        /// <summary>
        /// The prefab for what the npc's response resides in
        /// </summary>
        [SerializeField]
        protected SpeechBubble npcResponse;

        [SerializeField]
        protected SpeechBubble soundEffectSpeechBubble;

        /// <summary>
        /// The prefab for what the options button resides in
        /// </summary>
        [SerializeField]
        protected OptionsContainer optionsPrefab;

        [SerializeField]
        protected bool playOnAwake;

        [SerializeField]
        protected Canvas canvas;

        public event Action ConversationEnded;
        public UnityEvent ConversationComplete;
        
        /// <summary>
        /// The current conversation 
        /// </summary>
        public Conversation Current;

        public void Activate()
        {
            canvas.enabled = true;
            gameObject.SetActive(true);
            var statement = Current.GetFirst();
            DisplayStatement(statement);
        }

        public void DisplayNext(Statement statement)
        {
            if (statement.ChildrenAreOptions)
            {
                DisplayOptions(statement);
                FlowManager fm;
                if (FlowManager.TryGetInstance(out fm))
                {
                    fm.PauseVideo();
                }
            }
            else
            {
                if (!statement.IsLeaf)
                {
                    DisplayStatement(statement.Responses[0]);
                }
                else
                {
                    if (ConversationEnded != null)
                    {
                        ConversationEnded();
                    }
                    ConversationComplete.Invoke();
                }
            }
        }

        /// <summary>
        /// Displays the statment
        /// </summary>
        /// <param name="statement"></param>
        public void DisplayStatement(Statement statement)
        {
            if (optionsPrefab != null)
            {
                optionsPrefab.gameObject.SetActive(false);
            }
            if (statement == null)
            {
                return;
            }
            SpeechBubble selected;
            switch (statement.Mode)
            {
                case Statement.Type.NPC:
                    selected = npcResponse;
                    break;
                case Statement.Type.Player:
                    selected = playerStatement;
                    break;
                case Statement.Type.SoundEffect:
                    selected = soundEffectSpeechBubble;
                    break;
                default:
                    selected = null;
                    break;
            }
            if (selected == null)
            {
                return;
            }
            selected.gameObject.SetActive(true);
            selected.Play(this,statement);
        }

        /// <summary>
        /// The statement has reference to the options
        /// </summary>
        /// <param name="statement"></param>
        public void DisplayOptions(Statement statement)
        {
            playerStatement.gameObject.SetActive(false);
            optionsPrefab.Display(this, statement);
        }

        protected virtual void Awake()
        {
            if (playOnAwake)
            {
                Activate();
            }
        }

        private void OnValidate()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}