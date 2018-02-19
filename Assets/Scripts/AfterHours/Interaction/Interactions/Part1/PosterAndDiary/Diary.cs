using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Part1.PosterAndDiary
{
    public class Diary : Poster
    {
        [SerializeField]
        protected Sprite[] diaryPages;

        [SerializeField]
        protected Button diaryNavigationButton;

        [SerializeField] protected bool setState;
        
        private Image imageContainer;

        private int current;

        public UnityEvent complete;

        public override void Play()
        {
            base.Play();
            diaryNavigationButton.gameObject.SetActive(true);
        }
        
        public void Next()
        {
            current++;
            if (current >= diaryPages.Length)
            {
                complete.Invoke();
                
                
                gameObject.SetActive(false);
                backButton.gameObject.SetActive(setState);
                if (diaryNavigationButton != null)
                {
                    diaryNavigationButton.gameObject.SetActive(false);
                }
                if (postersAndDiary != null)
                {
                    postersAndDiary.TrackPostersInteractedWith(this);
                }
                return;
            }
            imageContainer.sprite = diaryPages[current];
        }

        protected override void Awake()
        {
            base.Awake();
            imageContainer = GetComponent<Image>();
        }
    }
}