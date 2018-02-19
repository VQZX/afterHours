using UnityEditor;
using UnityEngine;

namespace AfterHours.Editor
{
    [CustomEditor(typeof(CreateContent))]
    public class CreateContentHelper : UnityEditor.Editor
    {
        private CreateContent content;

        public override void OnInspectorGUI()
        {
            content = (CreateContent) target;
            
            base.OnInspectorGUI();

            if (GUILayout.Button("Make Contentn"))
            {
                content.MakeImages();
            }
        }
        
    }
}