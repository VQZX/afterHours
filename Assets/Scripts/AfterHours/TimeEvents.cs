using System;
using UnityEngine.Events;

namespace AfterHours
{
    [Serializable]
    public class TimeEvents
    {
        public float Minutes;

        public float Seconds;

        public UnityEvent TimeEvent;

        public bool ForcePlay;

        public float TotalSeconds
        {
            get { return Minutes * 60 + Seconds; }
        }

        public bool HasPlayed { get; private set; }

        public void SetHasPlayedByTime(float time)
        {
            HasPlayed = time > TotalSeconds;
        }

        public void CheckTimes(float time)
        {
            if (HasPlayed)
            {
                return;
            }
            if (time >= TotalSeconds)
            {
                TimeEvent.Invoke();
                HasPlayed = true;
            }
        }
    }
}
