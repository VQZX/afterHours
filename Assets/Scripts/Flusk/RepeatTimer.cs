using System;

namespace Flusk
{
    public class RepeatTimer : Timer
    {
        public RepeatTimer(float time, Action completeAction = null, Action<float> updateAction = null) : base(time, completeAction, updateAction)
        {
            CompletionCompleteAction += Reset;
        }
    }
}