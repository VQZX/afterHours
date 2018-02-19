using System;
using AfterHours.Menu;
using UnityEngine.EventSystems;

namespace AfterHours.Interaction.Interactions.Part1.PosterAndDiary
{
    public class PosterButton : SingleMethodButton
    {
        /// <summary>
        /// Tracks if the user has clicked on the poster
        /// </summary>
        public bool HasSelected { get; private set; }

        private PostersAndDiary manager;

        /// <inheritdoc />
        /// <summary>
        /// Set selected to true
        /// </summary>
        public override void AddOnClick(Action action)
        {
            base.AddOnClick(action);
            HasSelected = true;
        }

        public override void OnPointerClick(PointerEventData data)
        {
            base.OnPointerClick(data);
        }
        

        /// <summary>
        /// default HasSelected
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            HasSelected = false;
            manager = GetComponentInParent<PostersAndDiary>();
        }
    }
}
