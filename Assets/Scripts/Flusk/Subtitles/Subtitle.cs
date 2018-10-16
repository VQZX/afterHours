using System;
using Flusk.Strings;
using UnityEngine;

namespace Flusk.Subtitles
{
    [Serializable]
    public class Subtitle
    {
        [SerializeField]
        protected string subtitle;

        [SerializeField]
        protected AnimationCurve animationCurve;

        private bool complete;
        private bool clean;
        
        private StringCurveAnimator stringAnimator;

        private Timer timer;
        
        public Subtitle(string subtitle, AnimationCurve curve)
        {
            this.subtitle = subtitle;
            animationCurve = curve;
            Initialize();
            clean = false;
            complete = false;
        }

        public void Initialize()
        {
            stringAnimator = new StringCurveAnimator(subtitle, animationCurve);
            stringAnimator.Complete += OnComplete;
            timer = new Timer(1, Clean);
        }

        public string Render()
        {
            if (complete)
            {
                timer.Tick(Time.deltaTime);
            }

            if (clean)
            {
                return String.Empty;
            }
            return stringAnimator.CurrentText;
        }

        private void OnComplete()
        {
            complete = true;
        }

        private void Clean()
        {
            clean = true;
        }
    }
}