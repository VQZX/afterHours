using System;

namespace AfterHours
{
    [Serializable]
    public struct VideoTime
    {
        /// <summary>
        /// Monobehaviour that controls the events in unity
        /// </summary>
        public VideoEvent VideoEvent;

        /// <summary>
        /// Rounded down, the amount of minutes this plays at
        /// </summary>
        public float Minutes;

        /// <summary>
        /// The remainder seconds after the minutes
        /// </summary>
        public float Seconds;

        public bool HasPlayed;

        public static bool operator == (VideoTime first, VideoTime second)
        {
            return first.VideoEvent == second.VideoEvent;
        }
        
        public static bool operator != (VideoTime first, VideoTime second)
        {
            return first.VideoEvent != second.VideoEvent;
        }

        /// <summary>
        /// The total amount of seconds
        /// </summary>
        /// <returns></returns>
        public float TotalSeconds ()
        {
            return Minutes * 60 + Seconds;
        }
    }
}
