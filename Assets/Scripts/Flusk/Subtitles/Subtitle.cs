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
        
        private string[] sentences;
        private int currentSentence = 0;
        private StringCurveAnimator stringAnimator;
        
        public bool isMultiSubtitle { get; private set; }

        private const char SPLITTER = '.';

        public Subtitle(string subtitle, AnimationCurve curve)
        {
            this.subtitle = subtitle;
            animationCurve = curve;
            Initialize();
        }

        public void Initialize()
        {
            sentences = subtitle.Split(SPLITTER);
            isMultiSubtitle = sentences.Length > 1;
            stringAnimator = new StringCurveAnimator(sentences[currentSentence], animationCurve);
            if (isMultiSubtitle)
            {
                stringAnimator.Complete = OnComplete;
            }    
        }

        public string Render()
        {
            return stringAnimator.GetCurrent();
        }

        private void OnComplete()
        {
            currentSentence++;
            if (currentSentence >= sentences.Length)
            {
                return;
            }
            stringAnimator = new StringCurveAnimator(sentences[currentSentence], animationCurve);
        }
    }
}