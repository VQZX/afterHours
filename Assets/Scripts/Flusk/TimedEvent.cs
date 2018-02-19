using UnityEngine;
using UnityEngine.Events;

namespace Flusk
{
    public class TimedEvent : MonoBehaviour
    {
        /// <summary>
        /// The time
        /// </summary>
        [SerializeField]
        protected float time = 2;

        [SerializeField]
        protected bool playOnAwake;

        [SerializeField]
        protected UnityEvent timerComplete;

        public bool Playing { get; protected set; }

        private Timer timer;

        public void Activate()
        {
            Playing = true;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        protected virtual void Awake()
        {
            timer = new Timer(time, OnTimerEnd);
            Playing = playOnAwake;
        }

        /// <summary>
        /// Fires of any code after a time
        /// </summary>
        protected virtual void OnTimerEnd()
        {
            //code goes here
            timerComplete.Invoke();
        }

        protected virtual void Update()
        {
            if (!Playing)
            {
                return;
            }
            timer.Tick(Time.deltaTime);
        }


    }
}
