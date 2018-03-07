using System;

namespace Flusk
{
    public class RepeatTimer : Timer
    {
        public RepeatTimer(float time, Action complete = null, Action<float> updateAction = null) : base(time, complete, updateAction)
        {
            Complete = Reset;
        }
    }
}