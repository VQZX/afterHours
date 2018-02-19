using UnityEngine;
using UnityEngine.Video;

namespace AfterHours
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoEvents : MonoBehaviour
    {
        [SerializeField]
        protected TimeEvents[] times;

        private VideoPlayer player;

        private VideoHelper helper;

        private double startingTime;

        protected virtual void Awake()
        {
            player = GetComponent<VideoPlayer>();
            helper = GetComponent<VideoHelper>();
        }

        protected virtual void Start()
        {
            startingTime = helper.PlayBackPoint;
        }

        protected virtual void Update()
        {
            if (!player.isPlaying)
            {
                return;
            }

            foreach (TimeEvents timeEvents in times)
            {
                if (timeEvents.ForcePlay)
                {
                    timeEvents.CheckTimes((float)player.time);
                }
                else
                {
                    if (timeEvents.TotalSeconds < startingTime)
                    {
                        continue;
                    }
                    timeEvents.CheckTimes((float)player.time);
                }
            }
        }
        
        /// <summary>
        /// Subscribe
        /// </summary>
        protected virtual void OnEnable()
        {
            FlowManager fm;
            if (FlowManager.TryGetInstance(out fm))
            {
                fm.TimeSkipped += OnTimeSkipped;
            }
        }
    
        /// <summary>
        /// Unsubscribe
        /// </summary>
        protected virtual void OnDisable()
        {
            FlowManager fm;
            if (FlowManager.TryGetInstance(out fm))
            {
                fm.TimeSkipped -= OnTimeSkipped;
            }
        }
        
        private void OnTimeSkipped(double time)
        {
            foreach (TimeEvents timeEvents in times)
            {
                timeEvents.SetHasPlayedByTime((float)time);
            }
        }

    }
}
