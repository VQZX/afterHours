using System;
using Flusk.Extensions;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class Scribbles : VideoInteraction
    {
        [SerializeField]
        protected Scribble scribble;

        [SerializeField]
        protected RectTransform bounds;

        private Camera mainCamera;

        private Vector2 screenDimensions;
        private Vector2 offset;

        public void OnScribblesClicked()
        {
            Vector2 pointInScreen = screenDimensions.GetRandomPoint();
            scribble.RectTransform.localPosition  = pointInScreen;
        }

        public override void Show()
        {
            base.Show();
            OnScribblesClicked();
        }
        

        protected virtual void Awake()
        {
            screenDimensions = new Vector2(Screen.width, Screen.height);
            mainCamera = Camera.main;
        }
        
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            scribble = GetComponentInChildren<Scribble>();
            bounds = (RectTransform)scribble.transform.parent;
        }
#endif
        
        private bool TryPlaceScribble (Vector2 point)
        {
            Vector2 output;
            bool result = bounds.ScreenPointToRectangle(point, mainCamera, out output);
            if (result)
            {
                scribble.RectTransform.anchoredPosition = output;
            }
            Debug.Log(output);
            return result;
        }
    }
}