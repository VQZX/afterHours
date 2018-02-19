using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours
{
    public class ScaleTween : MonoBehaviour
    {
        [SerializeField]
        protected AnimationCurve curve;

        private bool animating;

        private float time;

        private float finalTime;

        private Vector3 originalScale;
        
        /// <summary>
        /// Called from animation
        /// </summary>
        public void Activate()
        {
            animating = true;
            time = 0;
            finalTime = curve[curve.length - 1].time;
            transform.localScale = originalScale;
        }

        protected virtual void Start()
        {
            originalScale = transform.localScale;
        }

        protected virtual void Update()
        {
            if (!animating)
            {
                return;
            }
            float value = 1 + curve.Evaluate(time);
            time += Time.deltaTime;
            transform.localScale = originalScale * value;

            if (time >= finalTime)
            {
                animating = false;
            }
        }
    }
}