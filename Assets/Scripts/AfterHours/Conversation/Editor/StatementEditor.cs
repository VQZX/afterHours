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
            if (statement == null)
            {
                statement = (Statement) target;
            }
            
            isEditingStatement = GUILayout.Button("Edit Statement");
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
            
            EditorUtility.SetDirty(target);
            
            base.OnInspectorGUI();
            
        }

        protected virtual void OnEnable()
        {
            statement = (Statement) target;
        }
        
    }
}