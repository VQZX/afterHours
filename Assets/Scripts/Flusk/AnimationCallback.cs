using UnityEngine;
using UnityEngine.Events;

namespace Flusk
{
    public class AnimationCallback : MonoBehaviour
    {
        public UnityEvent [] events;

        public void InvokeAnimationEvent(int i)
        {
            events[i].Invoke();
        }
    }
}