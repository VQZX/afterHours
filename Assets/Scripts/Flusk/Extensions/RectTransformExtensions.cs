using UnityEngine;

namespace Flusk.Extensions
{
    public static class RectTransformExtensions
    {
        public static Vector2 RandomPoint(this RectTransform transform)
        {
            float x = Random.Range(0, transform.rect.width);
            float y = Random.Range(0, transform.rect.height);

            return new Vector2(transform.rect.xMin, transform.rect.yMin) + new Vector2(x, y);
        }

        public static bool ScreenPointToRectangle(this RectTransform rect, Vector2 point, Camera camera, out Vector2 result)
        {
            return RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, point, camera, out result);
        }
    }
}