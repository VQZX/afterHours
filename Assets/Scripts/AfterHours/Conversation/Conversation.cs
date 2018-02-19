using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AfterHours.Conversation
{
    /// <summary>
    /// The container for the satements
    /// </summary>
    public class Conversation : MonoBehaviour
    {
        [SerializeField]
        protected List<Statement> children;
        
        public ConversationManager Manager { get; set; }
        
        public Statement Current { get; private set; }

        public Statement GetFirst()
        {
            Current = children[0];
            return Current;
        }
        
        protected virtual void Awake()
        {
            foreach (Statement child in children)
            {
                child.Selected += OnStatementSelected;
            }
        }
        
#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (children.Count != 0)
            {
                return;
            }
            var statements = GetComponentsInChildren<Statement>();
            children = new List<Statement>(statements);
        }
#endif

        private void OnStatementSelected(Statement statement)
        {
            if (children.Contains(statement))
            {
                Current = statement;
            }
        }
    }
}