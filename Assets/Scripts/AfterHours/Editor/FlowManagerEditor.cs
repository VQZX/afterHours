using System;
using UnityEditor;
using UnityEngine;

namespace AfterHours.Editor
{
    [CustomEditor(typeof(FlowManager))]
    public class FlowManagerEditor : UnityEditor.Editor
    {
        private FlowManager flowManager;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Create Event References!"))
            {
                flowManager.CreateEvents();
            }
        }
        
        protected virtual void OnEnable()
        {
            flowManager = (FlowManager) target;
        }
    }
}