using UnityEngine;
using UnityEngine.Video;

namespace AfterHours
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoToggle : MonoBehaviour
    {
        private VideoPlayer player;

        public bool IsPaused { get; protected set; }
        
        protected virtual void Start()
        {
            player = GetComponent<VideoPlayer>();
        }
        
        
        
        protected virtual void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                IsPaused = !IsPaused;
                if (IsPaused)
                {
                    player.Pause();
                }
                else
                {
                    player.Play();
                }
            }
        }
    }
}