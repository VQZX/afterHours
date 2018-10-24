using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class FacebookGalleryButton : Button
    {
        public enum Direction
        {
            Right,
            
            Left
        }
        
        [SerializeField]
        protected Image[] images;

        [SerializeField]
        protected Direction direction;

        public GameObject obsessImage { get; protected set; }

        private static int clicks;
        public static int Clicks
        {
            get { return clicks; }
        }

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
            clicks = direction == Direction.Right ? clicks + 1 : clicks -1;
            if (clicks < 0)
            {
                clicks = 0;
                return;
            }
            SetImageVisible();

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

        private void SetImageVisible()
        {
            for (var i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(i == clicks);
            }
        }
    }
}