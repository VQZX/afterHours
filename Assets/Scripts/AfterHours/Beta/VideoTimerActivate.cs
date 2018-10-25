using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace AfterHours.Beta
{
    public class VideoTimerActivate : MonoBehaviour
    {
        [SerializeField]
        protected List<Vector2> ranges;

        [SerializeField]
        protected VideoPlayer player;

        [SerializeField]
        protected UnityEvent begin, end;

        private List<Vector2> usedRanges = new List<Vector2>();
        private Vector2 nextRangeWaitingFor;
        private Vector2 currentRange;
        private bool isCurrentlyInRange;

        private void Start()
        {
            nextRangeWaitingFor = ranges[0];
        }

        private void Update()
        {
            if (isCurrentlyInRange)
            {
                if (player.time >= nextRangeWaitingFor.y)
                {
                    ranges.Remove(currentRange);
                    end.Invoke();
                    isCurrentlyInRange = false;
                    if (ranges.Count > 0)
                    {
                        nextRangeWaitingFor = ranges[0];
                    }
                    else
                    {
                        enabled = false;
                    }
                }
            }
            else
            {
                if (player.time >= nextRangeWaitingFor.x)
                {
                    currentRange = nextRangeWaitingFor;
                    isCurrentlyInRange = true;
                    begin.Invoke();
                } 
            }
        }
    }
}