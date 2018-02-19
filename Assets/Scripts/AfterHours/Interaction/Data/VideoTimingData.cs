using UnityEngine;

namespace AfterHours.Interaction.Data
{
    [CreateAssetMenu(fileName = "TimingData", menuName = "AfterHours/Timing Data", order = 0)]
    public class VideoTimingData : ScriptableObject
    {
        /// <summary>
        /// The timings and the associated prefabs
        /// </summary>
        [SerializeField]
        protected VideoTimingsList list;

        /// <summary>
        /// Accessor for the list
        /// </summary>
        public VideoTimingsList List
        {
            get { return list; }
        }

        /// <summary>
        /// Another easy accessor
        /// </summary>
        /// <param name="index"></param>
        public VideoTime this[int index]
        {
            get { return list[index]; }
        }
    }
}