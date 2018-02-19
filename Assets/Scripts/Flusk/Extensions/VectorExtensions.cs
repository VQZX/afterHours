using UnityEngine;

namespace Flusk.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 GetRandomPoint(this Vector2 vector)
        {
            return new Vector2(Random.Range(0, vector.x), Random.Range(0, vector.y));
        }
        
        public static Vector2 GetRandomPointBetween(this Vector2 vector, Vector2 max)
        {
            return new Vector2(Random.Range(vector.x, max.x), Random.Range(vector.y, max.y));
        }
    }
}