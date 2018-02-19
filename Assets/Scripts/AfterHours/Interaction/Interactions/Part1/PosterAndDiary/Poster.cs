using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1.PosterAndDiary
{
    [RequireComponent(typeof(Animation))]
    public class Poster : MonoBehaviour
    {
        protected new Animation animation;

        [SerializeField]
        protected GameObject backButton;

        protected PostersAndDiary postersAndDiary;
        
        public virtual void Play()
        {
            gameObject.SetActive(true);
        }

        protected virtual void Awake()
        {
            postersAndDiary = GetComponentInParent<PostersAndDiary>();
            animation = GetComponent<Animation>();
        }
    }
}