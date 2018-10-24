using UnityEditor;
using UnityEditor.UI;

namespace AfterHours.Interaction.Interactions.Tutorial.Editor
{
    [CustomEditor(typeof(FacebookGalleryButton))]
    public class FacebookGalleryButtonEditor : ButtonEditor
    {
        private FacebookGalleryButton button;

        private const string DIRECTION_PROPERTY_NAME = "direction";
        private const string CLICKS_PROPERTY_NAME = "clicks";
        
        private SerializedProperty directionProperty;
        private SerializedProperty clicksProperty;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            FacebookGalleryButton.Direction direction =
                (FacebookGalleryButton.Direction) directionProperty.enumValueIndex;
            direction = (FacebookGalleryButton.Direction)EditorGUILayout.EnumPopup(directionProperty.displayName, 
                direction);
            directionProperty.enumValueIndex = (int) direction;

            EditorGUILayout.LabelField("Clicks", FacebookGalleryButton.Clicks.ToString());
            
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(target);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            button = (FacebookGalleryButton) target;
            directionProperty = serializedObject.FindProperty(DIRECTION_PROPERTY_NAME);
            clicksProperty = serializedObject.FindProperty(CLICKS_PROPERTY_NAME);
        }
    }
}