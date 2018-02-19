using System.Collections.Generic;
using AfterHours.Interaction.Interactions.Part1.PosterAndDiary;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1
{
    public class PostersAndDiary : VideoInteraction
    {
        /// <summary>
        /// Amount before progressing
        /// </summary>
        [SerializeField]
        protected int postersRequiredForClicking = 3;
        
        /// <summary>
        /// The attached poster buttons
        /// </summary>
        private PosterButton[] posterButtons;

        /// <summary>
        /// The child diary buttons
        /// </summary>
        private DiaryButton diaryButton;

        /// <summary>
        /// Property for posters pressed
        /// </summary>
        public bool AllPostersPressed
        {
            get { return trackPostersClicked.Count >= postersRequiredForClicking; }
        }

        /// <summary>
        /// Property for tracking the diary has been read
        /// </summary>
        public bool HasDiaryBeenRead { get; private set; }

        /// <summary>
        /// Tracks all the posters that have been clicked
        /// </summary>
        private List<Poster> trackPostersClicked = new List<Poster>();

        private Poster currentActivePoster;

        /// <summary>
        /// Tracks the interaction with posters
        /// </summary>
        public void TrackPostersInteractedWith(Poster poster)
        {
            if (poster is Diary)
            {
                HasDiaryBeenRead = true;
                TryCallCompleteCheck();
                return;
            }
            if (trackPostersClicked.Contains(poster))
            {
                return;
            }
            trackPostersClicked.Add(poster);
            TryCallCompleteCheck();
        }

        public void SetCurrentActivePoster(Poster poster)
        {
            currentActivePoster = poster;
        }

        public void DeactivateCurrentPoster()
        {
            currentActivePoster.gameObject.SetActive(false);
            TrackPostersInteractedWith(currentActivePoster);
        }
        

        /// <summary>
        /// When the diary button is pressed
        /// </summary>
        private void OnDiaryButtonPressed()
        {
            HasDiaryBeenRead = true;
            TryCallCompleteCheck();
        }

        /// <summary>
        /// When all the buttons have been pressed
        /// </summary>
        private void TryCallCompleteCheck()
        {
            if (AllPostersPressed && HasDiaryBeenRead)
            {
                Hide();
            }   
        }
    }
}
