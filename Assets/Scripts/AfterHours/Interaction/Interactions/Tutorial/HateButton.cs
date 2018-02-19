using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    [RequireComponent(typeof(Button))]
    public class HateButton : MonoBehaviour
    {
        [SerializeField]
        protected GameObject associatedImage;

        private ThoughtsInteraction manager;

        private Button button;

        public void Assign(ThoughtsInteraction interaction)
        {
            manager = interaction;
        }

        public void Activate()
        {
            associatedImage.SetActive(true);
            gameObject.SetActive(true);
        }
        
        public void OnPressed()
        {
            manager.SelectHate(this);
            associatedImage.SetActive(false);
        }

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnPressed);
            gameObject.SetActive(false);
        }
        
    }
}