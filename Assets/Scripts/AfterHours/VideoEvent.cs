using UnityEngine;

namespace AfterHours
{
    public class VideoEvent : MonoBehaviour
    {
        /// <summary>
        /// Tells the FlowManager whether this should pause the video or not;
        /// </summary>
        [SerializeField] protected bool mustPauseVideo = true;

        /// <summary>
        /// Accesses the <see cref="mustPauseVideo"/> field
        /// </summary>
        public bool MustPauseVideo
        {
            get { return mustPauseVideo; }
        }

        public IVideoInteraction Interaction { get; protected set; }

        public virtual void RunInteraction ()
        {
            if ( Interaction == null )
            {
                Interaction = GetComponent<IVideoInteraction>();
                if ( Interaction == null )
                {
                    Debug.LogError("No interaction attached to gameobject");
                    return;
                }
            
            }
            Interaction.Show();
        }

        protected virtual void Awake ()
        {
            Interaction = GetComponent<IVideoInteraction>();
        }
    }
}
