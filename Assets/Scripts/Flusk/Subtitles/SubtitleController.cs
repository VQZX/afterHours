using System;
using System.Collections.Generic;
using AfterHours;
using UnityEngine;
using UnityEngine.UI;

namespace Flusk.Subtitles
{
    public class SubtitleController : Singleton<SubtitleController>
    {
        [SerializeField]
        protected Text subtitleText;

        [SerializeField]
        protected SubtitleList subtitles;

        [SerializeField]
        protected List<AudioClip> audioClips;

        private Subtitle current;

        public void Play(int index)
        {
            current = subtitles[index];
            current.Initialize();
        }

        public void Play()
        {
            current = subtitles.GetNext();
            current.Initialize();
        }

        public void Clear()
        {
            subtitleText.text = string.Empty;
            current = null;
        }

        protected virtual void Start()
        {
            subtitleText.text = string.Empty;

            AudioManager.Instance.ClipPlayed += OnClipPlayed;
        }
        
        protected virtual void Update()
        {
            if (current != null)
            {
                subtitleText.text = current.Render();
            }
        }

        private void OnDestroy()
        {
            AudioManager am;
            if (!AudioManager.TryGetInstance(out am))
            {
                return;
            }
            am.ClipPlayed -= OnClipPlayed;
        }

        private void OnClipPlayed(AudioClip clip)
        {
            if (!audioClips.Contains(clip))
            {
                return;
            }

            int index = audioClips.FindIndex( a => a == clip);
            if (index >= 0)
            {
                Play(index);
            }
        }
    }
}