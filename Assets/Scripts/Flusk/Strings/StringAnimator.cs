using System;
using Flusk.Extensions;
using UnityEngine;

namespace Flusk.Strings
{
    [Serializable]
    public class StringAnimator
    {
        protected float speed = 0.2f;
        
        public string Text { get; protected set; }
        public string CurrentText { get; protected set; }
        
        public float TotalTime { get; protected set; }
        public float CurrentTime { get; protected set; }

        protected int charLength;

        protected Timer timer;

        public Action Complete;

        public StringAnimator(string text, float time = 0.2f)
        {
            Text = text;
            CurrentText = string.Empty;
            timer = new Timer(time / speed, OnComplete, OnUpdate);
            TotalTime = time;
            charLength = Text.Length;
        }

        public virtual string GetCurrent()
        {
            UpdateTimer();
            return CurrentText;
        }
        

        public virtual void UpdateTimer()
        {
            if (timer != null)
            {
                timer.Tick(Time.deltaTime);
            }
        }

        protected virtual void OnUpdate(float time)
        {
            CurrentTime = time;
            int currentCharacterIndex = (int) time.Map(0, TotalTime, 0, charLength);
            SetString(currentCharacterIndex);
        }

        protected void SetString(int index)
        {
            for (int i = 0; i < index; i++)
            {
                CurrentText += Text[i];
            }
        }

        protected virtual void OnComplete()
        {
            CurrentText = Text;
            if (Complete != null)
            {
                Complete();
            }
        }
    }
}