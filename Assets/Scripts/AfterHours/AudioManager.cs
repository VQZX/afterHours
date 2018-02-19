using Flusk;
using UnityEngine;

namespace AfterHours
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource[] sources;

        public void PlayClip(AudioClip clip)
        {
            Debug.Log("Play Clip: "+clip.name);
            AudioSource source;
            if (TryFindAudioSource(out source))
            {
                source.clip = clip;
                source.Play();
            }
        }

        public void ResumeClip(AudioClip clip)
        {
            AudioSource source = FindSourceWithClip(clip);
            if (source == null)
            {
                return;
            }
            source.Play();
        }

        public void PauseClip(AudioClip clip)
        {
            AudioSource source = FindSourceWithClip(clip);
            if (source == null)
            {
                return;
            }
            source.Pause();
        }

        public void StopClip(AudioClip clip)
        {
            AudioSource source = FindSourceWithClip(clip);
            if (source == null)
            {
                return;
            }
            source.Stop();
            source.clip = null;
        }

        protected sealed override void Awake()
        {
            base.Awake();
            sources = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in sources)
            {
                source.loop = false;
            }
        }

        private bool TryFindAudioSource(out AudioSource source)
        {
            source = FindAvailableAudioSource();
            return source != null;
        }


        private AudioSource FindAvailableAudioSource()
        {
            foreach (AudioSource source in sources)
            {
                if (source.isPlaying)
                {
                    continue;
                }
                return source;
            }
            return null;
        }

        private AudioSource FindSourceWithClip(AudioClip clip)
        {
            foreach (AudioSource source in sources)
            {
                if (source.clip != clip)
                {
                    continue;
                }
                return source;
            }
            return null;
        }
    }
}
