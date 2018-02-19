using Flusk;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AfterHours.Interaction.Interactions.Tutorial
{
    public class ThoughtButton : Button
    {
        private ThoughtsInteraction interactionManager;

        private Timer timer;

        private new Animator animator;

        public Rect Rect { get; protected set; }

        public RectTransform RectTransform { get; protected set; }

        public ScaleTween ScaleTween { get; protected set; }

        public bool PostChaos { get; set; }

        public HateYourself AssignedHate { get; set; }

        public float hateDelay = 4;

        private Timer hateDelayer;

        public void AssignManager(ThoughtsInteraction manager)
        {
            interactionManager = manager;
        }

        public void AssignHate(HateYourself hateYourself)
        {
            AssignedHate = hateYourself;
            RectTransform.anchorMax = Vector2.one * 0.5f;
            RectTransform.anchorMin = Vector2.one * 0.5f;
            RectTransform.localPosition = Vector3.zero;
            transform.SetParent(AssignedHate.Position);
            RectTransform.localPosition = Vector3.zero;
            RectTransform.anchoredPosition = Vector2.zero;
            PostChaos = true;
            Activate();
            ScaleTween.enabled = false;
            RectTransform.localEulerAngles = Vector3.zero;
            var c = GetComponentInParent<CanvasGroup>();
            c.alpha = 1;

            hateDelayer = new Timer(hateDelay, Hate);
        }

        /// <summary>
        /// Activate the game object
        /// </summary>
        /// <param name="delay"></param>
        public void Display(float delay = 0)
        {
            gameObject.SetActive(true);
            animator = GetComponent<Animator>();
            image = GetComponent<Image>();
            ScaleTween = GetComponent<ScaleTween>();
            if (ScaleTween == null)
            {
                ScaleTween = gameObject.AddComponent<ScaleTween>();
            }
            animator.enabled = false;
            image.enabled = false;  
            if (delay <= float.Epsilon)
            {
                Activate();
            }
            else
            {
                gameObject.SetActive(true);
                timer = new Timer(delay, Activate);
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (HATE())
            {
                return;
            }
            base.OnPointerClick(eventData);
            interactionManager.MoveThought(this);
        }

        private void Hate()
        {
            HATE();
        }

        private bool HATE()
        {
            if (PostChaos)
            {
                if (AssignedHate != null)
                {
                    gameObject.SetActive(false);
                    AssignedHate.transform.parent.gameObject.SetActive(true);
                    AssignedHate.gameObject.SetActive(true);
                }
                return true;
            }
            return false;
        }

        protected override void Awake()
        {
            base.Awake();

            Rect = targetGraphic.rectTransform.rect;

            RectTransform = GetComponent<RectTransform>();

            animator = GetComponent<Animator>();
            image = GetComponent<Image>();
            animator.enabled = false;
            image.enabled = false;
        }

        protected virtual void Update()
        {
            if (timer != null && timer.Enabled)
            {
                timer.Tick(Time.deltaTime);
            }

            if (hateDelayer != null)
            {
                hateDelayer.Tick(Time.deltaTime);
            }

            if (PostChaos)
            {
                RectTransform.anchorMax = Vector2.one * 0.5f;
                RectTransform.anchorMin = Vector2.one * 0.5f;
                RectTransform.localPosition = Vector3.zero;
                transform.SetParent(AssignedHate.Position);
                RectTransform.localPosition = Vector3.zero;
                RectTransform.anchoredPosition = Vector2.zero;
            }
        }

        private void Activate()
        {
            animator.enabled = true;
            image.enabled = true;
            ScaleTween.Activate();
            interactionManager.MoveThought(this);
        }

        private void Deactivate()
        {
            animator.enabled = false;
            image.enabled = false;
        }
    }
}
