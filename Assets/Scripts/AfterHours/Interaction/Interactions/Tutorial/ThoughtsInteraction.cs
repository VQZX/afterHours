using System.Collections.Generic;
using Flusk.Extensions;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class ThoughtsInteraction : VideoInteraction
    {
        [SerializeField] 
        protected float maxRotation = 45f;
        
        [SerializeField] 
        protected float minRotation = -45f;

        [SerializeField]
        protected ThoughtButton[] thoughtButtons;

        [SerializeField]
        protected HateButton[] hateButtons;

        [SerializeField]
        protected HateYourself[] hateYourself;

        [SerializeField]
        protected RectTransform[] screenAreas;

        [SerializeField]
        protected RectTransform screenBounds;

        [SerializeField]
        protected float animationDelay = 0.5f;

        /// <summary>
        /// The fade out hate yourself animation
        /// </summary>
        [SerializeField]
        protected Animation hateYourselfAnimation;

        private List<FilledRectTransform> placementAreas;

        private int hateButtonsPressed;

        public void HateThoughts()
        {
            int length = thoughtButtons.Length;
            for (int i = 0; i < length; i++)
            {
                thoughtButtons[i].AssignHate(hateYourself[i]);
            }
        }

        public void MoveThought(ThoughtButton button)
        {
            Vector2 position = screenBounds.RandomPoint();
            button.RectTransform.anchoredPosition = position;
            button.RectTransform.localEulerAngles = Vector3.forward * Random.Range(minRotation, maxRotation);
            button.ScaleTween.Activate();
        }

        public void SelectHate(HateButton button)
        {
            int amount = Random.Range(1, 3 + hateButtonsPressed);
            int length = hateButtons.Length;
            amount = Mathf.Clamp(amount, 0, (int) (length * 0.5f) );
            List<HateButton> selected = new List<HateButton>();
            while (selected.Count < amount)
            {
                int index = Random.Range(0, length);
                var current = hateButtons[index];
                if ( !selected.Contains(current) && current != button)
                {
                    selected.Add(current);
                    current.Activate();
                }
            }
            hateButtonsPressed++;
            selected.Clear();
        }

        /// <summary>
        /// Display the buttons
        /// </summary>
        public override void Show()
        {
            GetComponent<Canvas>().enabled = true;
            float delay = 0;
            foreach (var thoughtButton in thoughtButtons)
            {
                thoughtButton.Display(delay);
                delay += animationDelay;
            }
        }

        /// <summary>
        /// Plays the hate yourself animation fade out
        /// </summary>
        public void PlayHateFadeOut()
        {
            hateYourselfAnimation.Play();
        }
        

        protected virtual void Awake()
        {
            minRotation = Mathf.Min(minRotation, maxRotation);
            maxRotation = Mathf.Max(minRotation, maxRotation);
            // assign the mananger to the buttons
            foreach (var thoughtButton in thoughtButtons)
            {
                thoughtButton.AssignManager(this);
            }

            foreach (var hate in hateButtons)
            {
                hate.Assign(this);
            }
            
            // initialise the filled areas
            placementAreas = new List<FilledRectTransform>();
            foreach (var area in screenAreas)
            {
                placementAreas.Add(new FilledRectTransform(area));
            }
        }
    }
}
