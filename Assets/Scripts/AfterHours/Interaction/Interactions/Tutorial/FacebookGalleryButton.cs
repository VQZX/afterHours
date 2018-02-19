using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class FacebookGalleryButton : Button
    {
        [SerializeField]
        private Image[] images;

        public GameObject obsessImage { get; protected set; }

        private int clicks;

        public void SetImages(Image[] image)
        {
            images = image;
        }

        public void SetObsess(GameObject obsess)
        {
            obsessImage = obsess;
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            clicks++;
            images[clicks - 1].gameObject.SetActive(false);
            if (clicks < images.Length)
            {
                images[clicks].gameObject.SetActive(true);
            }

            // The penultimate click
            if (clicks == images.Length - 2)
            {
                obsessImage.SetActive(false);
            }

            if (clicks >= images.Length - 1)
            {
                base.OnPointerClick(eventData);
            }
        }
    }
}