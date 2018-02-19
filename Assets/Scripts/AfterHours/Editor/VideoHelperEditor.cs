using System;
using UnityEditor;

namespace AfterHours.Editor
{
    [CustomEditor(typeof(VideoHelper))]
    public class VideoHelperEditor : UnityEditor.Editor
    {
        private VideoHelper videoHelper;
        private double length;
        private SerializedProperty playbackPoint;
        private SerializedProperty usePlaybackPoint;

        /// <inheritdoc />
        /// <summary>
        /// Draw the slider
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.Slider(playbackPoint, 0, (float)length, "Playback Point");

            double _seconds = playbackPoint.doubleValue;
            int _intSeconds = (int) _seconds;
            TimeSpan _timeSpan = TimeSpan.FromSeconds(_intSeconds);
            string _output = string.Format("{0:D2}:{1:D2}", _timeSpan.Minutes, _timeSpan.Seconds);

            EditorGUILayout.LabelField(_output);

            usePlaybackPoint.boolValue = EditorGUILayout.Toggle("Use Playback Point", usePlaybackPoint.boolValue);

            serializedObject.ApplyModifiedProperties();
            
        }

        /// <summary>
        /// Cache
        /// </summary>
        protected virtual void OnEnable()
        {
            videoHelper = (VideoHelper) target;
            length = videoHelper.Player.clip.length;
            playbackPoint = serializedObject.FindProperty("playBackPoint");
            usePlaybackPoint = serializedObject.FindProperty("usePlaybackPoint");
        }
    }
}
