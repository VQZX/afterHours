using UnityEngine;
using UnityEngine.EventSystems;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class LoveButton : MonoBehaviour, IPointerClickHandler
    {
        public RectTransform RectTransform
        {
            get { return (RectTransform) transform; }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInParent<LoveYourself>().OnPressed(this);
        }
    }
}