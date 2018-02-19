using System;
using System.Collections.Generic;
using UnityEngine;

namespace AfterHours.Interaction.Data
{
    /// <summary>
    /// For containing data on the video timings
    /// </summary>
    [Serializable]
    public class VideoTimingsList
    {
        
        /// <summary>
        /// The associated data
        /// </summary>
        [SerializeField]
        protected List<VideoTime> data;
        
        /// <summary>
        /// Reference to the current index
        /// </summary>
        public int CurrentIndex { get; private set; }
        
        /// <summary>
        /// Reference to the currnent data
        /// </summary>
        public VideoTime Current { get; private set; }

        /// <summary>
        /// The amount in the list
        /// </summary>
        public int Count
        {
            get { return data.Count; }
        }

        /// <summary>
        /// reference by index the video time
        /// </summary>
        /// <param name="index"></param>
        public VideoTime this[int index]
        {
            get { return data[index]; }
        }
        
        /// <summary>
        /// Initialise the properties
        /// </summary>
        public void Initialize()
        {
            CurrentIndex = 0;
            Current = data[CurrentIndex];
        }

        /// <summary>
        /// Sets the current element
        /// </summary>
        /// <param name="videoTime"></param>
        public void SetCurrent(VideoTime videoTime)
        {
            if (!data.Contains(videoTime))
            {
                return;
            }
            Current = videoTime;
            CurrentIndex = data.IndexOf(Current);
        }
        
        /// <summary>
        /// A safe way to get the next value
        /// </summary>
        public bool TryGetNext(ref VideoTime videoTime)
        {
            if (CurrentIndex + 1 >= data.Count)
            {
                return false;
            }
            videoTime = Next();
            return true;
        }

        /// <summary>
        /// A safer way to get the previous value
        /// </summary>
        /// <param name="videoTime"></param>
        /// <returns></returns>
        public bool TryGetPrevious(ref VideoTime videoTime)
        {
            if (CurrentIndex - 1 < 0)
            {
                return false;
            }
            videoTime = Next();
            return true;
        }
        
        /// <summary>
        /// Returns the next video timing
        /// </summary>
        public VideoTime Next()
        {
            CurrentIndex++;
            Current = data[CurrentIndex];
            return Current;
        }

        /// <summary>
        /// Returns the previous video timing
        /// </summary>
        public VideoTime Previous()
        {
            CurrentIndex--;
            Current = data[CurrentIndex];
            return Current;
        }

        public void Add(VideoTime time)
        {
            data.Add(time);
        }

        /// <summary>
        /// Returns if the current index is the final index
        /// </summary>
        public bool IsAtEnd()
        {
            return CurrentIndex == (data.Count-1);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoEvent"></param>
        public VideoTime AddVideoEvent(VideoEvent videoEvent)
        {
            VideoTime timing = default(VideoTime);
            timing.VideoEvent = videoEvent;
            data.Add(timing);
            return timing;
        }
        
        /// <summary>
        /// Returns true if there are any video times within time, false
        /// if the loops runs out video times. 
        /// </summary>
        public bool SetCurrentByTime(MinutesAndSeconds time, out VideoTime nextAppropriate)
        {
            float totalSeconds = time.TotalSeconds;
            foreach (VideoTime videoTime in data)
            {
                if (videoTime.TotalSeconds() < totalSeconds)
                {
                    continue;
                }
                nextAppropriate = Current = videoTime;
                CurrentIndex = data.FindIndex(FindIndex);
                return true;
            }
            nextAppropriate = Current = default(VideoTime);
            return false;
        }

        private bool FindIndex(VideoTime time)
        {
            return time == Current;
        }
    }
}