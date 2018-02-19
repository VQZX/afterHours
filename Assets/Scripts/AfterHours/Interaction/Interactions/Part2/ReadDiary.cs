using UnityEngine;
using UnityEngine.Video;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class ReadDiary : VideoInteraction
    {
        [SerializeField] protected VideoPlayer mainPlayer;

        [SerializeField] protected VideoPlayer looPlayer;
        
        public void StayWithHer()
        {
            mainPlayer.Stop();
            mainPlayer.gameObject.SetActive(false);
            looPlayer.Play();
            Hide();
        }

        public void Leave()
        {
            
        }
    }
    
}