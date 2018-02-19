using UnityEngine;

namespace AfterHours.Interaction
{
    [RequireComponent(typeof(Animation))]
    // ReSharper disable once InconsistentNaming
    public class UITween : MonoBehaviour
    {
        private new Animation animation;

        //private Canvas canvas;

        public void Show ()
        {
            animation.Play("Show");
        }

        public void Hide ()
        {
            animation.Play("Hide");
        }

        protected virtual void Awake ()
        {
            animation = GetComponent<Animation>();
            //canvas = GetComponent<Canvas>();
        }
    }
}
