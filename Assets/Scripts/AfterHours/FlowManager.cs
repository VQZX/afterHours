using System;
using System.Collections.Generic;
using AfterHours.Interaction.Data;
using Flusk;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Video;

namespace AfterHours
{
    public class FlowManager : Singleton<FlowManager>
    {
        [SerializeField] 
        protected List<VideoPlayer> players;
        
        /// <summary>
        /// The attached video player
        /// </summary>
        [SerializeField]
        protected VideoPlayer defaultPlayer;

        /// <summary>
        /// An array of timing data
        /// </summary>
        [SerializeField]
        protected VideoTimingData[] timingData;

        /// <summary>
        /// The parent for the video event canvases
        /// </summary>
        [SerializeField]
        protected RectTransform uiParent;

        /// <summary>
        /// A reference to the created data
        /// </summary>
        [SerializeField]
        protected VideoTimingsList timings;

        /// <summary>
        /// The present video helper
        /// </summary>
        [SerializeField]
        protected VideoHelper videoHelper;

        [SerializeField]
        protected bool autoLoadNextScene;

        /// <summary>
        /// TODO: would be nice if we could
        /// create a custom property drawer for this
        /// </summary>
        [SerializeField]
        protected string nextSceneToLoad;

        /// <summary>
        /// Fires when a time has been skipped
        /// </summary>
        public event Action<double> TimeSkipped;
        
        /// <summary>
        /// The current timing
        /// </summary>
        private VideoTime currentTiming;

        /// <summary>
        /// The current video player
        /// </summary>
        private VideoPlayer player;

        /// <summary>
        /// The time that the video begins at
        /// </summary>
        private double startTime;

        public void SetTime(double minutes, double seconds, bool mustPause = true)
        {
            player.time = minutes * 60 + seconds;
            player.Play();
            if (mustPause)
            {
                Invoke("PauseVideo", Time.deltaTime);
            }
            if (currentTiming.VideoEvent != null)
            {
                currentTiming.VideoEvent.Interaction.Response -= OnEventComplete;
            }
            if (timings.SetCurrentByTime(new MinutesAndSeconds((int) minutes, (int) seconds), out currentTiming))
            {
                currentTiming.VideoEvent.Interaction.Response += OnEventComplete; 
            }
            if (TimeSkipped != null)
            {
                TimeSkipped(player.time);
            }
        }

        public void PauseVideo()
        {
            player.Pause();
        }

        public void PlayVideo()
        {
            player.Play();   
        }
        
        public void CreateEvents()
        {
            int length = timingData.Length;
            for (int i = 0; i < length; i++)
            {
                VideoTimingData data = timingData[i];
                int count = timingData[i].List.Count;
                for (int j = 0; j < count; j++)
                {
                    var current = data[j];
                    var timeData = default(VideoTime);
#if UNITY_EDITOR
                    timeData.VideoEvent = (VideoEvent)PrefabUtility.InstantiatePrefab(current.VideoEvent);
#else
                    timeData.VideoEvent = Instantiate(current.VideoEvent, uiParent);
#endif
                    
                    timeData.VideoEvent.transform.SetParent(uiParent);
                    timeData.VideoEvent.transform.position = Vector3.zero;
                    timeData.VideoEvent.transform.localScale = Vector3.one;
                    
                    timeData.Minutes = current.Minutes;
                    timeData.Seconds = current.Seconds;
                    timings.Add(timeData);
                }
            }
        }
        
        /// <summary>
        /// Create everything
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
#if UNITY_EDITOR
            if (timings.Count == 0)
            {
                CreateEvents();
            }
#endif

            player = defaultPlayer;
            player.loopPointReached += OnVideoComplete;
        }
        
        /// <summary>
        /// Begin playing immediately
        /// </summary>
        protected virtual void Start ()
        {
            timings.Initialize();
            player.Play();
            startTime = videoHelper.PlayBackPoint;
            
            // select a reason timing
            if (videoHelper.UsePlaybackPoint)
            {
                for (int i = 0; i < timings.Count; i++)
                {
                    if (timings[i].TotalSeconds() < startTime)
                    {
                        continue;
                    }
                    currentTiming = timings[i];
                    timings.SetCurrent(currentTiming);
                    break;
                }
                if (currentTiming.VideoEvent == null)
                {
                    return;
                }
            }
            else
            {
                currentTiming = timings.Current;
                if (currentTiming.VideoEvent == null)
                {
                    currentTiming = timings[0];
                }
            }
            currentTiming.VideoEvent.Interaction.Response += OnEventComplete;
        }

        /// <summary>
        /// Keep track of the player's time and
        /// check against the interaction
        /// </summary>
        protected virtual void Update ()
        {

            if (player == null)
            {
                return;
            }
            
            if (currentTiming.VideoEvent == null)
            {
                return;
            }
            
            if (!player.isPlaying || !(player.time >= currentTiming.TotalSeconds()) || currentTiming.HasPlayed )
            {
                return;
            }
            currentTiming.HasPlayed = true;
            if (currentTiming.VideoEvent.MustPauseVideo)
            {
                player.Pause();
            }
            currentTiming.VideoEvent.RunInteraction();
        }

        /// <summary>
        /// Keeps track of when the video can resume
        /// </summary>
        private void OnEventComplete ()
        {
            if ( currentTiming.VideoEvent != null )
            {
                currentTiming.VideoEvent.Interaction.Response -= OnEventComplete;
            }
            player.Play();
            if ( timings.IsAtEnd() )
            {
                return;
            }
            currentTiming = timings.Next();
            currentTiming.VideoEvent.Interaction.Response += OnEventComplete;
        }

        private void OnVideoComplete(VideoPlayer source)
        {
            player.loopPointReached -= OnVideoComplete;
            int index = players.FindIndex(FindPlayer);
            index++;
            if (index >= players.Count)
            {
                if (autoLoadNextScene)
                {
                    // we have reached the end of the scene
                    GameManager gm;
                    if (GameManager.TryGetInstance(out gm))
                    {
                        gm.LoadScene(nextSceneToLoad);
                    }
                }
                return;
            }
            player = players[index];
            player.loopPointReached += OnVideoComplete;
        }

        private bool FindPlayer(VideoPlayer current)
        {
            return current == player;
        }
    }
}
