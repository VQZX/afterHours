using UnityEngine;
using UnityEngine.UI;

namespace AfterHours.Interaction
{
    public class BlurController : MonoBehaviour
    {
        [Range(0, 0.5f), SerializeField] protected float blurAmount;

        [SerializeField] protected Text text;
        
        protected virtual void Update()
        {
            text.material.SetFloat("_Blur", blurAmount);
        }
    }
}