using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Conversation.Editor
{
    [CustomEditor(typeof(Statement)), CanEditMultipleObjects]
    public class StatementEditor : UnityEditor.Editor
    {
        private Statement statement;

        private bool isEditingStatement;
        private bool isEditingOptions;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (statement == null)
            {
                statement = (Statement) target;
            }
            
            isEditingStatement = EditorGUILayout.Toggle("Edit Statement", isEditingStatement);
            isEditingOptions = EditorGUILayout.Toggle("Edit Options", isEditingOptions);

            if (isEditingStatement)
            {
                statement.SetStatementMeasurements( statement.SpeechBubble );
                
            }

            if (isEditingOptions)
            {  
                statement.SetOptionsMeasurements( statement.OptionsSpeechBubble );
            }

            if (GUILayout.Button("Set Content"))
            {
                statement.SetStatementRect();
            }
            
            if (GUILayout.Button("Set Options Content"))
            {
                statement.SetOptionsRect();
            }
            
        }

        protected virtual void OnEnable()
        {
            statement = (Statement) target;
        }
        
    }
}