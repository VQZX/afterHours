using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class Facebook : VideoInteraction
    {
        [SerializeField]
        protected Image[] images;

        [FormerlySerializedAs("button")]
        [SerializeField]
        protected FacebookGalleryButton rightArrow, leftArrow;

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
            rightArrow.SetImages(images);
            leftArrow.SetImages(images);
            rightArrow.SetObsess(obsessImage);
            leftArrow.SetObsess(obsessImage);
        }
    }
}