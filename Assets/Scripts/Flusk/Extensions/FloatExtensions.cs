namespace Flusk.Extensions
{
    public static class FloatExtensions
    {
        public static float Map(this float value, float inputMin, float inputMax, float outputMin, float outputMax)
        {
            float inputRange = inputMax - inputMin;
            float outputRange = outputMax - outputMin;
            float inputDifference = value - inputMin;
            float ratio = outputRange / inputRange;
            float outputDifference = ratio * inputDifference;
            return outputMin + outputDifference;
        }
    }
}