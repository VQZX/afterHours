using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part2
{
    public class LoveText : MonoBehaviour
    {
        [SerializeField]
        protected float increase = 0.3f;

        public void Clicked()
        {
            // tween scale up
            transform.localScale *= (1+increase);
        }
    }
}