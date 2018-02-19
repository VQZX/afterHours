#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace AfterHours
{
    [ExecuteInEditMode]
    public class VideoHelper : MonoBehaviour
    {
        /// <summary>
        /// The playback point
        /// </summary>
        [SerializeField, HideInInspector]
        protected double playBackPoint;
        public double PlayBackPoint { get { return playBackPoint; } }

        /// <summary>
        /// Whether or not to use it
        /// </summary>
        [SerializeField, HideInInspector]
        protected bool usePlaybackPoint;

        [SerializeField] protected UnityEvent played;

        [SerializeField]
        protected string currentTime;

        private VideoPlayer player;

        private const float ONE_OVER_SIXTY = 0.01666666666f;
        
        
        public bool UsePlaybackPoint
        {
            get { return usePlaybackPoint; }
        }



        public VideoPlayer Player
        {
            get
            {
                if (player == null)
                {
                    player = GetComponent<VideoPlayer>();
                }
                return player;
            }
        }

        public void Seek(double seconds)
        {
            player.time = seconds;
        }
        
#if UNITY_EDITOR
        protected virtual void Awake()
        {
            
            if (usePlaybackPoint && player.playOnAwake && (EditorApplication.isPlaying || Application.isPlaying) )
            {
                player.time = playBackPoint;
                player.Play();

                played.Invoke();
            }
        }
#else
        protected virtual void Awake()
        {
            playBackPoint = 0;
            usePlaybackPoint = false;
            Player.Play();
        }
#endif
    

        

#if UNITY_EDITOR

        protected virtual void Update()
        {
            if (player != null)
            {
                int minutes = (int) Mathf.Floor(((float) player.time) * ONE_OVER_SIXTY);
                int seconds = (int) (((float) player.time) % 60);
                currentTime = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            }
        }

        protected virtual void OnValidate()
        {
            player = GetComponent<VideoPlayer>();
        }
#endif
    }
}
