using System;
using UnityEngine;
using UnityEngine.Events;

namespace AfterHours.Interaction
{
    public class VideoInteraction : MonoBehaviour, IVideoInteraction
    {
        [SerializeField]
        protected UITween uiTween;

        [SerializeField]
        protected UnityEvent Begin;

        [SerializeField]
        protected UnityEvent End;
    
        //TODO: remove; its repetitive and redundant
        public Action Response
        {
            get { return response; }
            set { response = value; }
        }

        private Action response;


        public virtual void Show ()
        {
            Begin.Invoke();
            uiTween.Show();
        }

        public virtual void Hide ()
        {
            End.Invoke();
            uiTween.Hide();
            if ( Response != null )
            {
                Response();
            }
        }

        public virtual void SafeHide ()
        {
            End.Invoke();
            uiTween.Hide();
        }

        public virtual void ExternalResponse ()
        {
            if (Response != null)
            {
                Response();
            }
        }

#if UNITY_EDITOR
        protected virtual void OnValidate ()
        {
            uiTween = GetComponent<UITween>();
        }
#endif
    }
}
