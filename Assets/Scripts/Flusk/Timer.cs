using System;
using UnityEngine;

namespace Flusk
{
    public class Timer
    {
        public float CompletionTime { get; protected set; }

        public bool Complete { get; protected set; }

        public Action CompletionCompleteAction;

        public Action<float> UpdateAction;

        public float CurrentTime { get; protected set; }
        
        public bool Enabled { get; private set; }

        public Timer(float time, Action completeAction = null, Action<float> updateAction = null)
        {
            CompletionTime = time;
            CompletionCompleteAction = completeAction;
            UpdateAction = updateAction;
            Enabled = true;
        }

        public virtual void Tick(float deltaTime)
        {
            if (!Enabled)
            {
                return;
            }
            CurrentTime += deltaTime;
            if (UpdateAction != null)
            {
                UpdateAction(CurrentTime);
            }
            if (CurrentTime < CompletionTime)
            {
                return;
            }
            if (CompletionCompleteAction == null)
            {
                return;
            }
            CompletionCompleteAction();
            Complete = true;
            Enabled = false;
        }

        public void Reset()
        {
            CurrentTime = 0;
        }
    }
}
