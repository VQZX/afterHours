using UnityEngine;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class HateYourself : MonoBehaviour
    {
        [SerializeField]
        protected Transform position;
        
        public ThoughtButton thoughtButton { get; protected set; }
        
        public Transform Position
        {
            get { return position; }
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (position == null)
            {
                position = transform.GetChild(0);
            }
        }
#endif
    }
}