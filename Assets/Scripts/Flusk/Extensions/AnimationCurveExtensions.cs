using UnityEngine;

namespace Flusk.Extensions
{
    public delegate float Filter(float a, float b);
    
    public static class AnimationCurveExtensions
    {
        public static float Max(this AnimationCurve curve)
        {
            return curve.Check(Mathf.Max, -float.MaxValue);
        }
        
        public static float Min(this AnimationCurve curve)
        {
            return curve.Check(Mathf.Min, float.MaxValue);
        }

        private static float Check(this AnimationCurve curve, Filter filter, float start)
        {
            float result = start;
            float currentTime = curve.FirstTime();
            float maxTime = curve.FinalTime();

            while (currentTime <= maxTime)
            {
                float current = curve.Evaluate(currentTime);
                result = filter(result, current);
                currentTime += Time.deltaTime;
            }

            return result;
        }

        public static float FinalTime(this AnimationCurve curve)
        {
            return curve[curve.length - 1].time;
        }

        public static float FirstTime(this AnimationCurve curve)
        {
            return curve[0].time;
        }
    }
}