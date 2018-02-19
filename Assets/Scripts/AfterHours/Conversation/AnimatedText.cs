using System;
using Flusk;
using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Conversation
{
    [RequireComponent(typeof(Text))]
    public class AnimatedText : MonoBehaviour
    {
        [Multiline(2), SerializeField]
        protected string text;

        [Range(0, 1), SerializeField]
        protected float timePerCharacter = 0.3f;

        [SerializeField]
        protected Method method = Method.Simple;

        [SerializeField]
        protected AnimationCurve speedCurve;

        [SerializeField]
        protected bool playOnAwake;

        private Text uiText;

        public float TotalTime { get; set; }

        public Action Complete;

        private Timer textTimer;

        private float curveTime;
        private float curveMax;

        private bool complete;
        
        public void Play(string playText, float setTimePerCharacter = 0.3f)
        {
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(true);
            }
            
            text = playText;
            timePerCharacter = setTimePerCharacter;
            method = Method.Simple;
            Play();
        }

        public void Play(string playText, AnimationCurve curve)
        {
            gameObject.SetActive(true);
            text = playText;
            speedCurve = curve;
            method = Method.AnimationCurve;
            if (speedCurve.length == 0)
            {
                method = Method.Simple;
                Play();
                return;
            }
            curveTime = speedCurve[speedCurve.length - 1].time;
            float sample = Time.fixedDeltaTime;
            int samples = (int) (curveTime / sample);
            curveMax = -float.MaxValue;
            for (int i = 0; i < samples; i++)
            {
                float currentTime = sample * i;
                curveMax = Mathf.Max(curveMax, speedCurve.Evaluate(currentTime));
            }
            Play();
        }

        private void Play()
        {
            uiText.text = string.Empty;
            TotalTime = text.Length * timePerCharacter;
            textTimer = new Timer(TotalTime, TimerComplete, TimerUpdate);
        }

        protected virtual void Awake()
        {
            uiText = GetComponent<Text>();
            if (playOnAwake)
            {
                Play();
            }  
        }

        protected virtual void Update()
        {
            if (textTimer != null)
            {
                textTimer.Tick(Time.deltaTime);
            }
        }
        
        private void TimerUpdate(float currentTime)
        {
            switch (method)
            {
                case Method.Simple:
                    SimpleMethod(currentTime);
                    break;
                case Method.AnimationCurve:
                    AnimationCurveMethod(currentTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }        
        }
        
        private void TimerComplete()
        {
            uiText.text = text;
            if (Complete != null)
            {
                Complete();
            }
            textTimer = null;
        }

        private void SimpleMethod(float time)
        {
            Write(time / TotalTime);
        }
        
        //TODO: DO THIS PROPERLY!!!!
        private void AnimationCurveMethod(float time)
        {
            float ratio = time / TotalTime;
            float speedTime = curveTime * ratio;
            if (speedTime >= curveTime)
            {
                TimerComplete();
                return;
            }
            Write(speedCurve.Evaluate(speedTime) / curveMax);
        }

        private void Write(float ratio)
        {
            int index = Mathf.CeilToInt(ratio * text.Length);
            int length = text.Length;
            string output = string.Empty;
            for (int i = 0; i < index; i++)
            {
                if (index >= length)
                {
                    continue;
                }
                output += text[i];
            }
            if (output.Length >= uiText.text.Length)
            {
                uiText.text = output;
            }   
        }
        
        public enum Method
        {
            Simple,
            
            AnimationCurve
        }
    }
}