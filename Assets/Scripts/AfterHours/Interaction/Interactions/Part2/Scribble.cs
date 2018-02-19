using UnityEngine;
using UnityEngine.EventSystems;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class Scribble : MonoBehaviour, IPointerClickHandler
    {
        private Scribbles scribbles;

        public RectTransform RectTransform
        {
            get { return (RectTransform) transform; }
        }
        
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (scribbles == null)
            {
                return;
            }
            scribbles.OnScribblesClicked();
        }

        protected virtual void Awake()
        {
            scribbles = GetComponentInParent<Scribbles>();
        }
    }
}