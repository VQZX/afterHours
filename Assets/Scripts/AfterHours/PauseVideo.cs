using UnityEngine;
using UnityEngine.Video;

namespace AfterHours
{
    public class PauseVideo : MonoBehaviour
    {
        [SerializeField]
        protected KeyCode pauseKey = KeyCode.P;

        [SerializeField] protected VideoPlayer player;

        public bool isPaused { get; private set; }

        public void Update()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                isPaused = !isPaused;
                if (isPaused)
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
