using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class Facebook : VideoInteraction
    {
        [SerializeField]
        protected Image[] images;

        [SerializeField]
        protected FacebookGalleryButton button;

        [SerializeField] protected GameObject obsessImage;

        [Header("Restart time")]
        [SerializeField]
        protected int minutes;

        [SerializeField]
        protected int seconds;

        public override void Show()
        {
            base.Show();
            FlowManager.Instance.SetTime(minutes, seconds);
        }
       
        protected virtual void Awake()
        {
            button.SetImages(images);
            button.SetObsess(obsessImage);
        }
    }
}