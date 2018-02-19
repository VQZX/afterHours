using Flusk;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class CircleBob : MonoBehaviour
    {
        [SerializeField]
        protected AnimationCurve xCurve;

        [SerializeField]
        protected AnimationCurve yCurve;

        [SerializeField]
        protected float xRadius, yRadius;

        protected float minTime;
        
        private bool isRunning;

        private RepeatTimer timer;

        private Vector2 originalAnchored;

        public RectTransform RectTransform
        {
            get { return (RectTransform) transform; }
        }

        public void Run()
        {
            isRunning = true;
            originalAnchored = RectTransform.anchoredPosition;
            timer = new RepeatTimer(minTime);
        }

        public void Stop()
        {
            isRunning = false;
        }

        protected virtual void Start()
        {
            float xTime = xCurve[xCurve.length - 1].time;
            float yTime = yCurve[yCurve.length - 1].time;

            minTime = Mathf.Min(xTime, yTime); 
        }

        protected virtual void Update()
        {
            if (!isRunning)
            {
                return;
            }
            float currentTime = timer.CompletionTime;
            float x = xCurve.Evaluate(currentTime) * xRadius;
            float y = yCurve.Evaluate(currentTime) * yRadius;
            RectTransform.anchoredPosition = new Vector2(x,y);
        }
    }
}