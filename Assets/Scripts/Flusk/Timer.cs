using System;
using UnityEngine;

namespace Flusk
{
    public class Timer
    {
        public float CompletionTime { get; protected set; }

        public bool Ended { get; protected set; }

        public Action Complete;

        public Action<float> Update;

        public float CurrentTime { get; protected set; }
        
        public bool Enabled { get; private set; }

        public Timer(float time, Action complete = null, Action<float> update = null)
        {
            CompletionTime = time;
            Complete = complete;
            Update = update;
            Enabled = true;
        }

        public virtual void Tick(float deltaTime)
        {
            if (!Enabled)
            {
                return;
            }
            CurrentTime += deltaTime;
            if (Update != null)
            {
                Update(CurrentTime);
            }
            if (CurrentTime < CompletionTime)
            {
                return;
            }
            if (Complete == null)
            {
                return;
            }
            Complete();
            Ended = true;
            Enabled = false;
        }

        public void Reset()
        {
            CurrentTime = 0;
        }
    }
}
