using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace AfterHours
{
    public class TimedVideoEvent : MonoBehaviour
    {
        /// <summary>
        /// The time when the event will go off
        /// </summary>
        [SerializeField]
        protected MinutesAndSeconds fireTime;
        
        /// <summary>
        /// The vidoe player to sampler
        /// </summary>
        [SerializeField]
        protected VideoPlayer player;

        /// <summary>
        /// The event for when the point is reached
        /// </summary>
        [SerializeField]
        protected UnityEvent reachedPlayPoint;


        /// <summary>
        /// Tracks if the event has fired
        /// </summary>
        private bool hasPlayed;

        protected virtual void Update()
        {
            if (!hasPlayed && player.time >= fireTime.TotalSeconds)
            {
                hasPlayed = true;
                reachedPlayPoint.Invoke();
            }
        }
    }
}