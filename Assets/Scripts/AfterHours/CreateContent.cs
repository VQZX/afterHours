using UnityEngine;
using UnityEngine.UI;

namespace AfterHours
{
    public class CreateContent : MonoBehaviour
    {
        [SerializeField] protected Sprite[] images;

        public void MakeImages()
        {
            for (int i = 0; i < images.Length; i++)
            {
                var sprite = images[i];
                GameObject current = new GameObject(sprite.name);
                var image = current.AddComponent<Image>();
                image.sprite = sprite;
                current.transform.SetParent(transform);
            }
        }
    }
}